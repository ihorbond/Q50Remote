using Q50Remote.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command<string> SendCarCommand { get; }
        public Command Unlock { get; }
        //public ICommand Lock { get; }
        //public ICommand Lock { get; }
        //public ICommand Lock { get; }

        public MainPageViewModel()
        {
            SendCarCommand = new Command<string>((carCommand) =>
            {
                var name = Enum.GetName(typeof(CarCommandEnum), carCommand);
                Debug.WriteLine(name);
            });
        }
    }
}
