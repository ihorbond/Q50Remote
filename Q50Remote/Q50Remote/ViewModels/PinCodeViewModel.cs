using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Q50Remote.ViewModels
{
    public class PinCodePageViewModel: BaseViewModel
    {
        private Entry _pinCodeEntry { get; }
        private bool _isPinCodeSet { get; }
        private string _pinCode { get; set; }
        private string _greetingMsg { get; set; }
        public string GreetingMsg
        {
            get => _greetingMsg;
            set
            {
                _greetingMsg = value;
                OnPropertyChanged();
            }
        }
        private string _pinCodeInput { get; set; } = "";
        public string PinCodeInput
        {
            get => _pinCodeInput;
            set
            {
                _pinCodeInput = value;
                OnPropertyChanged();

                if(value.Length == 4)
                    _pinCodeEntry.Unfocus();
            }
        }
        private bool _isErrorLabelVisible { get; set; }
        public bool IsErrorLabelVisible
        {
            get => _isErrorLabelVisible;
            set
            {
                _isErrorLabelVisible = value;
                OnPropertyChanged();
            }
        }

        public PinCodePageViewModel() { }

        public PinCodePageViewModel(ContentPage view)
        {
            _pinCodeEntry = view.FindByName<Entry>("PinCodeEntry");
            _pinCodeEntry.Unfocused += PinCodeEntry_Unfocused;

            _pinCode = Preferences.Get("PIN", null);
            _isPinCodeSet = _pinCode != null;
            GreetingMsg = _isPinCodeSet ? "Enter PIN" : "Create PIN";
        }

        private void PinCodeEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (!_isPinCodeSet && PinCodeInput.Length == 4)
            {
                Preferences.Set("PIN", PinCodeInput);
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                if (_pinCode != PinCodeInput)
                    IsErrorLabelVisible = _pinCode != PinCodeInput;
                else
                    Application.Current.MainPage = new NavigationPage(new MainPage());
            }
        }
    }
}
