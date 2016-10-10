using System;
using System.Linq;
using System.Linq.Expressions;

namespace TramStationTracks
{
    public static class Modifiers
    {
        public static void RemoveTramStopAndPoles(NetInfo prefab)
        {
            if (prefab == null || prefab.m_lanes == null)
            {
                return;
            }
            foreach (var lane in prefab.m_lanes)
            {
                var mLaneProps = lane.m_laneProps;
                if (mLaneProps == null)
                {
                    continue;
                }
                var props = mLaneProps.m_props;
                if (props == null)
                {
                    continue;
                }
                lane.m_laneProps = new NetLaneProps
                {
                    m_props = (from prop in props
                               where prop != null
                               let mProp = prop.m_prop
                               where mProp != null
                               where !mProp.name.Contains("Tram Stop Sign")
                               where !mProp.name.Contains("Tram Pole Side")
                               select prop).ToArray()
                };
            }
        }

        public static void RemoveStreetLights(NetInfo prefab)
        {
            if (prefab == null || prefab.m_lanes == null)
            {
                return;
            }
            foreach (var lane in prefab.m_lanes)
            {
                var mLaneProps = lane.m_laneProps;
                if (mLaneProps == null)
                {
                    continue;
                }
                var props = mLaneProps.m_props;
                if (props == null)
                {
                    continue;
                }
                lane.m_laneProps = new NetLaneProps
                {
                    m_props = (from prop in props
                               where prop != null
                               let mProp = prop.m_prop
                               where mProp != null
                               where !mProp.name.Contains("Light")
                               select prop).ToArray()
                };
            }
        }

        public static void UpdatePedestrianLanes(NetInfo prefab)
        {
            if (prefab == null || prefab.m_lanes == null)
            {
                return;
            }
            foreach (var lane in prefab.m_lanes.Where(lane => lane != null && lane.m_laneType == NetInfo.LaneType.Pedestrian))
            {
                lane.m_verticalOffset = 0.60f;
                lane.m_allowConnect = true;
                lane.m_useTerrainHeight = false;
                lane.m_direction = NetInfo.Direction.AvoidForward;
                lane.m_finalDirection = NetInfo.Direction.AvoidForward;
            }
        }
    }

}