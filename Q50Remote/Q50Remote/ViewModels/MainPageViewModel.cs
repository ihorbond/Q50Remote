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
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class MainPageViewModel : SettingsPageBaseViewModel
    {
        private bool _isCarCommandRunning = false;
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

            ShowCarLocation = new Command(() =>
            {
                Debug.WriteLine("Show location");
            });

            ShowAutoPIPortal = new Command(() =>
            {
                Debug.WriteLine("Show auto pi portal");

            });

            ShowSettings = new Command(async() =>
            {
                Debug.WriteLine("Show settings");
                await Application.Current.MainPage.Navigation.PushAsync(new Settings(), true);
            });
        }

    }
}
