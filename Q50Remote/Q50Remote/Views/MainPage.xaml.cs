using Q50Remote.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Q50Remote
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //reattaching view model to trigger one way binding to refresh
            MainPageViewModel vm = new MainPageViewModel();
            BindingContext = vm;
        }

    }
}
