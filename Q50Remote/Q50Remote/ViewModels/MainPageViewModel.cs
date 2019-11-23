using Q50Remote.Enums;
using Q50Remote.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _carCommandNotRunning = true;
        public bool CarCommandNotRunning
        {
            get => _carCommandNotRunning;
            set
            {
                _carCommandNotRunning = value;
                OnPropertyChanged(nameof(CarCommandNotRunning));
            }
        }
        public Command<CarCommandEnum> SendCarCommand { get; }
        private AutoPiService _autoPiService { get; }

        public MainPageViewModel()
        {
            _autoPiService = new AutoPiService();

            SendCarCommand = new Command<CarCommandEnum>(async(carCommand) =>
            {
                CarCommandNotRunning = false;

                string name = Enum.GetName(typeof(CarCommandEnum), carCommand);
                Debug.WriteLine(name);

                await _autoPiService.SendCommand();

                Debug.WriteLine(name);

                CarCommandNotRunning = true;
            });
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
