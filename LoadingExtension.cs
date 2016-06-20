using ICities;
using UnityEngine;

namespace TramStationTracks
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public static Initializer Container;

        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);

            if (Container == null)
            {
                Container = new GameObject("TramStationTrack").AddComponent<Initializer>();
            }
            Util.AddLocale("NET", "Tram Station Track", "Tram Station Track", "Tram Station Track");
        }

        public override void OnReleased()
        {
            base.OnReleased();
            if (Container == null)
            {
                return;
            }
            Object.Destroy(Container.gameObject);
            Container = null;
        }
    }
}