using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsLockTileVisible)] = value;
        }
        public bool IsUnlockTileVisible
        {
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsUnlockTileVisible)] = value;
        }
        public bool IsTrunkTileVisible
        {
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsTrunkTileVisible)] = value;
        }
        public bool IsAlarmTileVisible
        {
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsAlarmTileVisible)] = value;
        }
        public bool IsWindowsTileVisible
        {
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsWindowsTileVisible)] = value;
        }
        public bool IsLocationTileVisible
        {
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsLocationTileVisible)] = value;
        }
        public bool IsAutoPiTileVisible
        {
            get => GetConfigValue();
            set => Application.Current.Properties[nameof(IsAutoPiTileVisible)] = value;
        }

        /// <summary>
        /// Return true by default
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool GetConfigValue([CallerMemberName]string key = "")
        {
            return Application.Current.Properties.ContainsKey(key)
                ? (bool)Application.Current.Properties[key]
                : true;
        }

    }
}
