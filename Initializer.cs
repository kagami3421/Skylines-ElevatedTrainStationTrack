using System;
using System.Linq;

namespace TramStationTracks
{
    public class Initializer : AbstractInitializer
    {
        protected override void InitializeImpl()
        {
            CreatePrefab("Tram Station Track", "Tram Track", SetupTramStationTrackAction()
                .Chain(Modifiers.UpdatePedestrianLanes)
                .Chain(Modifiers.RemoveStreetLights)
                .Chain(Modifiers.RemoveTramStopAndPoles));
        }

        private static Action<NetInfo> SetupTramStationTrackAction()
        {
            return newPrefab =>
            {
                newPrefab.GetComponent<RoadAI>().m_bridgeInfo = null;
                newPrefab.GetComponent<RoadAI>().m_elevatedInfo = null;
                newPrefab.GetComponent<RoadAI>().m_slopeInfo = null;
                newPrefab.GetComponent<RoadAI>().m_tunnelInfo = null;
                newPrefab.m_flattenTerrain = true;
                newPrefab.m_followTerrain = false;
                newPrefab.m_availableIn = ItemClass.Availability.GameAndAsset;
                newPrefab.m_snapBuildingNodes = false;
                newPrefab.m_placementStyle = ItemClass.Placement.Procedural;
                newPrefab.m_isCustomContent = true;
                newPrefab.m_dlcRequired = SteamHelper.DLC_BitMask.SnowFallDLC;
            };
        }
    }
}
