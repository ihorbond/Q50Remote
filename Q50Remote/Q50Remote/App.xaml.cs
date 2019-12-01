using Q50Remote.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q50Remote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PinCodePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            //ShowAuth();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            //ShowAuth();


            // Handle when your app resumes
        }

        private async void ShowAuth()
        {
            await Current.MainPage.Navigation.PopToRootAsync();
            MainPage = new PinCodePage();
        }
    }
}
