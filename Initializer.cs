using System;
using UnityEngine;

namespace ElevatedTrainStationTrack
{
    public class Initializer : AbstractInitializer
    {
        protected override void InitializeImpl()
        {
            CreatePrefab("Highway Bridge Vip", "Highway Bridge", SetupElevatedPrefab);
        }

        private static void SetupElevatedPrefab(NetInfo elevatedPrefab)
        {
            SetupElevatedPrefab(elevatedPrefab, false);
        }

        private static void SetupElevatedPrefab(NetInfo elevatedPrefab, bool concrete)
        {
            var elevatedTrack = FindOriginalPrefab("Highway Bridge");
            if (elevatedTrack == null)
            {
                return;
            }
            var etstMesh = Util.LoadMesh(string.Concat(Util.AssemblyDirectory, "/bridgev2.obj"), "ETST ");
            var etstSegmentLodMesh = Util.LoadMesh(string.Concat(Util.AssemblyDirectory, "/bridgev2.obj"), "ETST_SLOD");
            elevatedPrefab.m_segments[1].m_segmentMaterial = elevatedTrack.m_segments[0].m_segmentMaterial;
            elevatedPrefab.m_segments[1].m_material = elevatedTrack.m_segments[0].m_material;
            elevatedPrefab.m_segments[1].m_mesh = etstMesh;
            elevatedPrefab.m_segments[1].m_segmentMesh = etstMesh;
            elevatedPrefab.m_segments[1].m_lodMaterial = elevatedTrack.m_segments[0].m_lodMaterial;
            elevatedPrefab.m_segments[1].m_lodMesh = etstSegmentLodMesh;
        }
    }
}
