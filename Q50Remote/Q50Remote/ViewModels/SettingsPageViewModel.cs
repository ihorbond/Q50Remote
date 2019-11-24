using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class SettingsPageViewModel: SettingsPageBaseViewModel
    {
        public SettingsPageViewModel()
        {
        }

        public string AutoPiURL
        {
            get => Application.Current.Properties.ContainsKey(nameof(AutoPiURL))
                ? (string)Application.Current.Properties[nameof(AutoPiURL)]
                : "";

            set => Application.Current.Properties[nameof(AutoPiURL)] = value;
        }

    }

}
