using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
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
        private const int PIN_CODE_LENGTH = 4;
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

                if(value.Length == PIN_CODE_LENGTH)
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
            GetExistingPinCode();

            _pinCodeEntry = view.FindByName<Entry>("PinCodeEntry");
            _pinCodeEntry.Unfocused += PinCodeEntry_Unfocused;
            _isPinCodeSet = _pinCode != null;
            GreetingMsg = _isPinCodeSet ? "Enter PIN" : "Create PIN";

            if (_isPinCodeSet)
                AuthenticateViaFingerPrint();

        }

        private async void AuthenticateViaFingerPrint()
        {
            var authParams = new AuthenticationRequestConfiguration("Please scan fingerprint")
            {
                AllowAlternativeAuthentication = false,
                UseDialog = true,
                CancelTitle = "Use PIN"
            };

            FingerprintAuthenticationResult authResult = await CrossFingerprint.Current.AuthenticateAsync(authParams);
            if(authResult.Authenticated)
            {
                PinCodeInput = _pinCode;
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                Debug.WriteLine(authResult.Status, authResult.ErrorMessage);
                _pinCodeEntry.Focus();
            }
        }

        private async void GetExistingPinCode()
        {
            try
            {
                _pinCode = await SecureStorage.GetAsync("PIN");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void PinCodeEntry_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                IsErrorLabelVisible = _isPinCodeSet && _pinCode != PinCodeInput || PinCodeInput.Length != PIN_CODE_LENGTH;

                if (!_isPinCodeSet && PinCodeInput.Length == PIN_CODE_LENGTH)
                {
                    await SecureStorage.SetAsync("PIN", PinCodeInput);
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                else if(!IsErrorLabelVisible)
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }
    }
}
