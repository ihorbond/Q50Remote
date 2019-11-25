using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class SettingsPageViewModel: SettingsPageBaseViewModel
    {
        public Command ShowAppInfoCommand { get; }

        public SettingsPageViewModel()
        {
            ShowAppInfoCommand = new Command(() =>
            {
                AppInfo.ShowSettingsUI();
            });
        }

    }

}
