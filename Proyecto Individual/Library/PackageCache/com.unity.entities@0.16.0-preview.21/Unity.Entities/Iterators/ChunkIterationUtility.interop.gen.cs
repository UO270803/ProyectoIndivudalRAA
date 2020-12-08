
//------------------------------------------------------------------------------
// <auto-generated>
//     This file was automatically generated by Unity.Entities.Editor.BurstInteropCodeGenerator
//     Any changes you make here will be overwritten
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     To update this file, use the "DOTS -> Regenerate Burst Interop" menu option.
//
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Unity.Burst;
using Unity.Collections;
using System.Runtime.InteropServices;

namespace Unity.Entities
{
     unsafe partial struct ChunkIterationUtility
    {

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)

        [BurstDiscard]
        private static void CheckDelegate(ref bool useDelegate)
        {
            //@TODO: This should use BurstCompiler.IsEnabled once that is available as an efficient API.
            useDelegate = true;
        }

        private static bool UseDelegate()
        {
            bool result = false;
            CheckDelegate(ref result);
            return result;
        }

        static class Managed
        {
            public static bool _initialized = false;

            public delegate void _dlg_GatherChunks(in UnsafeMatchingArchetypePtrList matchingArchetypesList, IntPtr offsets, IntPtr chunks);
            public static _dlg_GatherChunks _bfp_GatherChunks;
            public delegate void _dlg_GatherChunksWithFilter(in UnsafeMatchingArchetypePtrList matchingArchetypePtrList, ref EntityQueryFilter filter, IntPtr offsets, IntPtr filteredCounts, IntPtr sparseChunks);
            public static _dlg_GatherChunksWithFilter _bfp_GatherChunksWithFilter;
            public delegate void _dlg_JoinChunks(IntPtr DestinationOffsets, IntPtr SparseChunks, IntPtr Offsets, IntPtr JoinedChunks, int archetypeCount);
            public static _dlg_JoinChunks _bfp_JoinChunks;
            public delegate void _dlg_GatherEntities(IntPtr entities, ref EntityQuery entityQuery, ref EntityTypeHandle entityTypeHandle);
            public static _dlg_GatherEntities _bfp_GatherEntities;
            public delegate void _dlg_GatherComponentData(IntPtr componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter);
            public static _dlg_GatherComponentData _bfp_GatherComponentData;
            public delegate void _dlg_CopyComponentArrayToChunks(IntPtr componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter);
            public static _dlg_CopyComponentArrayToChunks _bfp_CopyComponentArrayToChunks;
            public delegate int _dlg_CalculateChunkAndEntityCount(ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter, out int chunkCount);
            public static _dlg_CalculateChunkAndEntityCount _bfp_CalculateChunkAndEntityCount;
            public delegate int _dlg_CalculateChunkCount(ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter);
            public static _dlg_CalculateChunkCount _bfp_CalculateChunkCount;
            public delegate int _dlg_CalculateEntityCount(ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter);
            public static _dlg_CalculateEntityCount _bfp_CalculateEntityCount;
            public delegate void _dlg_RebuildChunkListCache(IntPtr queryData);
            public static _dlg_RebuildChunkListCache _bfp_RebuildChunkListCache;
        }


#endif

        [NotBurstCompatible]
        internal static void Initialize()
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (Managed._initialized)
                return;
            Managed._initialized = true;
            Managed._bfp_GatherChunks = BurstCompiler.CompileFunctionPointer<Managed._dlg_GatherChunks>(_mono_to_burst_GatherChunks).Invoke;
            Managed._bfp_GatherChunksWithFilter = BurstCompiler.CompileFunctionPointer<Managed._dlg_GatherChunksWithFilter>(_mono_to_burst_GatherChunksWithFilter).Invoke;
            Managed._bfp_JoinChunks = BurstCompiler.CompileFunctionPointer<Managed._dlg_JoinChunks>(_mono_to_burst_JoinChunks).Invoke;
            Managed._bfp_GatherEntities = BurstCompiler.CompileFunctionPointer<Managed._dlg_GatherEntities>(_mono_to_burst_GatherEntities).Invoke;
            Managed._bfp_GatherComponentData = BurstCompiler.CompileFunctionPointer<Managed._dlg_GatherComponentData>(_mono_to_burst_GatherComponentData).Invoke;
            Managed._bfp_CopyComponentArrayToChunks = BurstCompiler.CompileFunctionPointer<Managed._dlg_CopyComponentArrayToChunks>(_mono_to_burst_CopyComponentArrayToChunks).Invoke;
            Managed._bfp_CalculateChunkAndEntityCount = BurstCompiler.CompileFunctionPointer<Managed._dlg_CalculateChunkAndEntityCount>(_mono_to_burst_CalculateChunkAndEntityCount).Invoke;
            Managed._bfp_CalculateChunkCount = BurstCompiler.CompileFunctionPointer<Managed._dlg_CalculateChunkCount>(_mono_to_burst_CalculateChunkCount).Invoke;
            Managed._bfp_CalculateEntityCount = BurstCompiler.CompileFunctionPointer<Managed._dlg_CalculateEntityCount>(_mono_to_burst_CalculateEntityCount).Invoke;
            Managed._bfp_RebuildChunkListCache = BurstCompiler.CompileFunctionPointer<Managed._dlg_RebuildChunkListCache>(_mono_to_burst_RebuildChunkListCache).Invoke;

#endif
        }

        private  static void GatherChunks (in UnsafeMatchingArchetypePtrList matchingArchetypesList, int* offsets, ArchetypeChunk* chunks)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_GatherChunks(in matchingArchetypesList, offsets, chunks);
                return;
            }
#endif

            _GatherChunks(in matchingArchetypesList, offsets, chunks);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_GatherChunks))]
        private static void _mono_to_burst_GatherChunks(in UnsafeMatchingArchetypePtrList matchingArchetypesList, IntPtr offsets, IntPtr chunks)
        {
            _GatherChunks(in matchingArchetypesList, (int*)offsets, (ArchetypeChunk*)chunks);
        }

        [BurstDiscard]
        private static void _forward_mono_GatherChunks(in UnsafeMatchingArchetypePtrList matchingArchetypesList, int* offsets, ArchetypeChunk* chunks)
        {
            Managed._bfp_GatherChunks(in matchingArchetypesList, (IntPtr) offsets, (IntPtr) chunks);
        }
#endif

        private  static void GatherChunksWithFilter (in UnsafeMatchingArchetypePtrList matchingArchetypePtrList, ref EntityQueryFilter filter, int* offsets, int* filteredCounts, ArchetypeChunk* sparseChunks)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_GatherChunksWithFilter(in matchingArchetypePtrList, ref filter, offsets, filteredCounts, sparseChunks);
                return;
            }
#endif

            _GatherChunksWithFilter(in matchingArchetypePtrList, ref filter, offsets, filteredCounts, sparseChunks);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_GatherChunksWithFilter))]
        private static void _mono_to_burst_GatherChunksWithFilter(in UnsafeMatchingArchetypePtrList matchingArchetypePtrList, ref EntityQueryFilter filter, IntPtr offsets, IntPtr filteredCounts, IntPtr sparseChunks)
        {
            _GatherChunksWithFilter(in matchingArchetypePtrList, ref filter, (int*)offsets, (int*)filteredCounts, (ArchetypeChunk*)sparseChunks);
        }

        [BurstDiscard]
        private static void _forward_mono_GatherChunksWithFilter(in UnsafeMatchingArchetypePtrList matchingArchetypePtrList, ref EntityQueryFilter filter, int* offsets, int* filteredCounts, ArchetypeChunk* sparseChunks)
        {
            Managed._bfp_GatherChunksWithFilter(in matchingArchetypePtrList, ref filter, (IntPtr) offsets, (IntPtr) filteredCounts, (IntPtr) sparseChunks);
        }
#endif

        private  static void JoinChunks (int* DestinationOffsets, ArchetypeChunk* SparseChunks, int* Offsets, ArchetypeChunk* JoinedChunks, int archetypeCount)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_JoinChunks(DestinationOffsets, SparseChunks, Offsets, JoinedChunks, archetypeCount);
                return;
            }
#endif

            _JoinChunks(DestinationOffsets, SparseChunks, Offsets, JoinedChunks, archetypeCount);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_JoinChunks))]
        private static void _mono_to_burst_JoinChunks(IntPtr DestinationOffsets, IntPtr SparseChunks, IntPtr Offsets, IntPtr JoinedChunks, int archetypeCount)
        {
            _JoinChunks((int*)DestinationOffsets, (ArchetypeChunk*)SparseChunks, (int*)Offsets, (ArchetypeChunk*)JoinedChunks, archetypeCount);
        }

        [BurstDiscard]
        private static void _forward_mono_JoinChunks(int* DestinationOffsets, ArchetypeChunk* SparseChunks, int* Offsets, ArchetypeChunk* JoinedChunks, int archetypeCount)
        {
            Managed._bfp_JoinChunks((IntPtr) DestinationOffsets, (IntPtr) SparseChunks, (IntPtr) Offsets, (IntPtr) JoinedChunks, archetypeCount);
        }
#endif

        private  static void GatherEntities (Entity* entities, ref EntityQuery entityQuery, ref EntityTypeHandle entityTypeHandle)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_GatherEntities(entities, ref entityQuery, ref entityTypeHandle);
                return;
            }
#endif

            _GatherEntities(entities, ref entityQuery, ref entityTypeHandle);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_GatherEntities))]
        private static void _mono_to_burst_GatherEntities(IntPtr entities, ref EntityQuery entityQuery, ref EntityTypeHandle entityTypeHandle)
        {
            _GatherEntities((Entity*)entities, ref entityQuery, ref entityTypeHandle);
        }

        [BurstDiscard]
        private static void _forward_mono_GatherEntities(Entity* entities, ref EntityQuery entityQuery, ref EntityTypeHandle entityTypeHandle)
        {
            Managed._bfp_GatherEntities((IntPtr) entities, ref entityQuery, ref entityTypeHandle);
        }
#endif

        private  static void GatherComponentData (byte* componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_GatherComponentData(componentData, typeIndex, ref chunkIter);
                return;
            }
#endif

            _GatherComponentData(componentData, typeIndex, ref chunkIter);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_GatherComponentData))]
        private static void _mono_to_burst_GatherComponentData(IntPtr componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter)
        {
            _GatherComponentData((byte*)componentData, typeIndex, ref chunkIter);
        }

        [BurstDiscard]
        private static void _forward_mono_GatherComponentData(byte* componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter)
        {
            Managed._bfp_GatherComponentData((IntPtr) componentData, typeIndex, ref chunkIter);
        }
#endif

        public  static void CopyComponentArrayToChunks (byte* componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_CopyComponentArrayToChunks(componentData, typeIndex, ref chunkIter);
                return;
            }
#endif

            _CopyComponentArrayToChunks(componentData, typeIndex, ref chunkIter);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_CopyComponentArrayToChunks))]
        private static void _mono_to_burst_CopyComponentArrayToChunks(IntPtr componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter)
        {
            _CopyComponentArrayToChunks((byte*)componentData, typeIndex, ref chunkIter);
        }

        [BurstDiscard]
        private static void _forward_mono_CopyComponentArrayToChunks(byte* componentData, int typeIndex, ref ArchetypeChunkIterator chunkIter)
        {
            Managed._bfp_CopyComponentArrayToChunks((IntPtr) componentData, typeIndex, ref chunkIter);
        }
#endif

        public  static int CalculateChunkAndEntityCount (ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter, out int chunkCount)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                var _retval = default(int);
                _forward_mono_CalculateChunkAndEntityCount(ref _retval, ref matchingArchetypes, ref filter, out chunkCount);
                return _retval;
            }
#endif

            return _CalculateChunkAndEntityCount(ref matchingArchetypes, ref filter, out chunkCount);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_CalculateChunkAndEntityCount))]
        private static int _mono_to_burst_CalculateChunkAndEntityCount(ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter, out int chunkCount)
        {
            return _CalculateChunkAndEntityCount(ref matchingArchetypes, ref filter, out chunkCount);
        }

        [BurstDiscard]
        private static void _forward_mono_CalculateChunkAndEntityCount(ref int _retval, ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter, out int chunkCount)
        {
            _retval = Managed._bfp_CalculateChunkAndEntityCount(ref matchingArchetypes, ref filter, out chunkCount);
        }
#endif

        public  static int CalculateChunkCount (ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                var _retval = default(int);
                _forward_mono_CalculateChunkCount(ref _retval, ref matchingArchetypes, ref filter);
                return _retval;
            }
#endif

            return _CalculateChunkCount(ref matchingArchetypes, ref filter);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_CalculateChunkCount))]
        private static int _mono_to_burst_CalculateChunkCount(ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter)
        {
            return _CalculateChunkCount(ref matchingArchetypes, ref filter);
        }

        [BurstDiscard]
        private static void _forward_mono_CalculateChunkCount(ref int _retval, ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter)
        {
            _retval = Managed._bfp_CalculateChunkCount(ref matchingArchetypes, ref filter);
        }
#endif

        public  static int CalculateEntityCount (ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                var _retval = default(int);
                _forward_mono_CalculateEntityCount(ref _retval, ref matchingArchetypes, ref filter);
                return _retval;
            }
#endif

            return _CalculateEntityCount(ref matchingArchetypes, ref filter);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_CalculateEntityCount))]
        private static int _mono_to_burst_CalculateEntityCount(ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter)
        {
            return _CalculateEntityCount(ref matchingArchetypes, ref filter);
        }

        [BurstDiscard]
        private static void _forward_mono_CalculateEntityCount(ref int _retval, ref UnsafeMatchingArchetypePtrList matchingArchetypes, ref EntityQueryFilter filter)
        {
            _retval = Managed._bfp_CalculateEntityCount(ref matchingArchetypes, ref filter);
        }
#endif

        public  static void RebuildChunkListCache (EntityQueryData* queryData)
        {
#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
            if (UseDelegate())
            {
                _forward_mono_RebuildChunkListCache(queryData);
                return;
            }
#endif

            _RebuildChunkListCache(queryData);
        }

#if !(UNITY_2020_1_OR_NEWER && UNITY_IOS)
        [BurstCompile]
        [MonoPInvokeCallback(typeof(Managed._dlg_RebuildChunkListCache))]
        private static void _mono_to_burst_RebuildChunkListCache(IntPtr queryData)
        {
            _RebuildChunkListCache((EntityQueryData*)queryData);
        }

        [BurstDiscard]
        private static void _forward_mono_RebuildChunkListCache(EntityQueryData* queryData)
        {
            Managed._bfp_RebuildChunkListCache((IntPtr) queryData);
        }
#endif




    }
}