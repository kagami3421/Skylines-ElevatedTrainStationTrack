using ICities;
using UnityEngine;

namespace OneWayTrainTrack
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public static Initializer Container;

        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);

            if (Container == null)
            {
                Container = new GameObject("OneWayTrainTrack").AddComponent<Initializer>();
            }
            Util.AddLocale("NET", "Oneway Train Track", "One-way Train Track", "One-way Train Track");
            Util.AddLocale("NET", "Oneway Train Track Bridge", "One-way Train Track ", "One-way Train Track");
            Util.AddLocale("NET", "Oneway Train Track Elevated", "One-way Train Track", "One-way Train Track");
            Util.AddLocale("NET", "Oneway Train Track Tunnel", "One-way Train Track", "One-way Train Track");
            Util.AddLocale("NET", "Oneway Train Track slope", "One-way Train Track", "One-way Train Track");
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