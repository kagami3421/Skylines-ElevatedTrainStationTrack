using ColossalFramework.UI;
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
            if (Util.IsModActive("One-Way Train Tracks"))
            {
                return;
            }
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

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel").SetMessage(
            "Mod deprecated",
            "'One-Way Train Track' mod is now DEPRECATED!\nUnsubscribe it and subscribe to a newer better version called 'One-Way Train Tracks'.\nOne-way train tracks you already placed won't disappear; they will automatically convert to the new version.",
            false);

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