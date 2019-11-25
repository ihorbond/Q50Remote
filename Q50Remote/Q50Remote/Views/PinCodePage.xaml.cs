using Q50Remote.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q50Remote.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinCodePage : ContentPage
    {
        public PinCodePage()
        {
            InitializeComponent();
            BindingContext = new PinCodePageViewModel(this);
        }

    }
}