using Q50Remote.Enums;
using Q50Remote.Models;
using Q50Remote.Services;
using Q50Remote.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class MainPageViewModel : SettingsPageViewModel
    {
        private bool _isCarCommandRunning;
        public bool IsCarCommandRunning
        {
            get => _isCarCommandRunning;
            set
            {
                _isCarCommandRunning = value;
                OnPropertyChanged();
            }
        }

        private int _actIndRow;
        public int ActIndRow
        {
            get => _actIndRow;
            set
            {
                _actIndRow = value;
                OnPropertyChanged();
            }
        }

        private int _actIndCol;
        public int ActIndCol
        {
            get => _actIndCol;
            set
            {
                _actIndCol = value;
                OnPropertyChanged();
            }
        }

        public Command<CarCommandEnum> SendCarCommand { get; }
        public Command ShowCarLocation { get; }
        public Command ShowAutoPIPortal { get; }
        public Command ShowSettings { get; }
        private AutoPiService _autoPiService { get; }

        public MainPageViewModel()
        {
            _autoPiService = new AutoPiService();

            SendCarCommand = new Command<CarCommandEnum>(async(carCommand) =>
            {
                IsCarCommandRunning = true;
                
                string name = Enum.GetName(typeof(CarCommandEnum), carCommand);
                Debug.WriteLine(name);

                await _autoPiService.SendCommand();

                Debug.WriteLine(name);

                IsCarCommandRunning = false;
            });

            ShowCarLocation = new Command(async() =>
            {
                Debug.WriteLine("Show location");
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    await Launcher.OpenAsync("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA");
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // open the maps app directly
                    await Launcher.OpenAsync("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
                }
            });

            ShowAutoPIPortal = new Command(async() =>
            {
                Debug.WriteLine("Show auto pi portal");
                string url = AutoPiURL ?? "https://my.autopi.io/#/login";

                await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage(url));

            });

            ShowSettings = new Command(async() =>
            {
                Debug.WriteLine("Show settings");
                await Application.Current.MainPage.Navigation.PushAsync(new Settings(), true);
            });
        }

    }
}
