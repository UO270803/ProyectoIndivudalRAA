using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Unity.PerformanceTesting.Data;
using Unity.PerformanceTesting.Editor;
using Unity.PerformanceTesting.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

[assembly: PrebuildSetup(typeof(TestRunBuilder))]
[assembly: PostBuildCleanup(typeof(TestRunBuilder))]

namespace Unity.PerformanceTesting.Editor
{
    public class TestRunBuilder : IPrebuildSetup, IPostBuildCleanup, IPreprocessBuildWithReport
    {
        private const string cleanResources = "PT_ResourcesCleanup";

        public int callbackOrder
        {
            get { return 0; }
        }

        public void OnPreprocessBuild(BuildReport report)
        {
            var run = CreateRunInfo();

            CreateResourcesFolder();
            CreatePerformanceTestRunJson(run);
        }

        public void Setup()
        {
            var run = CreateRunInfo();
            EditorPrefs.SetBool(cleanResources, false);
            CreatePerformancePlayerPreferences(run);
        }

        static List<string> GetPackageDependencies()
        {
            var listRequest = UnityEditor.PackageManager.Client.List(true);
            while (!listRequest.IsCompleted)
                System.Threading.Thread.Sleep(10);
            if (listRequest.Status == UnityEditor.PackageManager.StatusCode.Failure)
                Debug.LogError("Failed to list local packages");
            var packages = new List<UnityEditor.PackageManager.PackageInfo>(listRequest.Result);
            var reformated = packages.Select(p => $"{p.name}@{p.version}").ToList();
            return reformated;
        }

        public void Cleanup()
        {
            if (File.Exists(Utils.TestRunPath))
            {
                File.Delete(Utils.TestRunPath);
                File.Delete(Utils.TestRunPath + ".meta");
            }

            if (EditorPrefs.GetBool(cleanResources))
            {
                Directory.Delete("Assets/Resources/", true);
                File.Delete("Assets/Resources.meta");
            }

            AssetDatabase.Refresh();
        }

        private static Data.Editor GetEditorInfo()
        {
            var fullVersion = UnityEditorInternal.InternalEditorUtility.GetFullUnityVersion();
            const string pattern = @"(.+\.+.+\.\w+)|((?<=\().+(?=\)))";
            var matches = Regex.Matches(fullVersion, pattern);

            return new Data.Editor
            {
                Branch = GetEditorBranch(),
                Version = matches[0].Value,
                Changeset = matches[1].Value,
                Date = UnityEditorInternal.InternalEditorUtility.GetUnityVersionDate(),
            };
        }

        private static string GetEditorBranch()
        {
            foreach (var method in typeof(UnityEditorInternal.InternalEditorUtility).GetMethods())
            {
                if (method.Name.Contains("GetUnityBuildBranch"))
                {
                    return (string) method.Invoke(null, null);
                }
            }

            return "null";
        }

        private static void SetBuildSettings(Run run)
        {
            if (run.Player == null) run.Player = new Player();

            run.Player.GpuSkinning = PlayerSettings.gpuSkinning;
            run.Player.ScriptingBackend = PlayerSettings
                .GetScriptingBackend(EditorUserBuildSettings.selectedBuildTargetGroup).ToString();
            run.Player.RenderThreadingMode = PlayerSettings.graphicsJobs ? "GraphicsJobs" :
                PlayerSettings.MTRendering ? "MultiThreaded" : "SingleThreaded";
            run.Player.AndroidTargetSdkVersion = PlayerSettings.Android.targetSdkVersion.ToString();
            run.Player.AndroidBuildSystem = EditorUserBuildSettings.androidBuildSystem.ToString();
            run.Player.BuildTarget = EditorUserBuildSettings.activeBuildTarget.ToString();
            run.Player.StereoRenderingPath = PlayerSettings.stereoRenderingPath.ToString();
        }

        public Run CreateRunInfo()
        {
            var run = new Run();
            run.Editor = GetEditorInfo();
            run.Dependencies = GetPackageDependencies();
            SetBuildSettings(run);
            run.Date = Utils.ConvertToUnixTimestamp(DateTime.Now);

            return run;
        }

        public Run GetPerformanceTestRun()
        {
            var run = CreateRunInfo();
            Metadata.SetRuntimeSettings(run);

            return run;
        }


        private void CreateResourcesFolder()
        {
            if (Directory.Exists(Utils.ResourcesPath))
            {
                EditorPrefs.SetBool(cleanResources, false);
                return;
            }

            EditorPrefs.SetBool(cleanResources, true);
            AssetDatabase.CreateFolder("Assets", "Resources");
        }

        private void CreatePerformanceTestRunJson(Run run)
        {
            var json = CreatePerformancePlayerPreferences(run);
            File.WriteAllText(Utils.TestRunPath, json);
            AssetDatabase.Refresh();
        }

        private string CreatePerformancePlayerPreferences(Run run)
        {
            var json = JsonConvert.SerializeObject(run, Formatting.Indented);
            PlayerPrefs.SetString(Utils.PlayerPrefKeyRunJSON, json);
            return json;
        }
    }
}