using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class SettingsPageBaseViewModel: BaseViewModel
    {
        public SettingsPageBaseViewModel()
        {

        }

        public bool IsLockTileVisible
        {
            get => Preferences.Get(nameof(IsLockTileVisible), true);
            set => Preferences.Set(nameof(IsLockTileVisible), value);
        }
        public bool IsUnlockTileVisible
        {
            get => Preferences.Get(nameof(IsUnlockTileVisible), true);
            set => Preferences.Set(nameof(IsUnlockTileVisible), value);
        }
        public bool IsTrunkTileVisible
        {
            get => Preferences.Get(nameof(IsTrunkTileVisible), true);
            set => Preferences.Set(nameof(IsTrunkTileVisible), value);
        }
        public bool IsAlarmTileVisible
        {
            get => Preferences.Get(nameof(IsAlarmTileVisible), true);
            set => Preferences.Set(nameof(IsAlarmTileVisible), value);
        }
        public bool IsWindowsTileVisible
        {
            get => Preferences.Get(nameof(IsWindowsTileVisible), true);
            set => Preferences.Set(nameof(IsWindowsTileVisible), value);
        }
        public bool IsLocationTileVisible
        {
            get => Preferences.Get(nameof(IsLocationTileVisible), true);
            set => Preferences.Set(nameof(IsLocationTileVisible), value);
        }
        public bool IsAutoPiTileVisible
        {
            get => Preferences.Get(nameof(IsAutoPiTileVisible), true);
            set => Preferences.Set(nameof(IsAutoPiTileVisible), value);
        }
        public string AutoPiURL
        {
            get => Preferences.Get(nameof(AutoPiURL), null);
            set => Preferences.Set(nameof(AutoPiURL), value);
        }

    }
}
