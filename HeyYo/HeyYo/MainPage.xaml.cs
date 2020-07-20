using HeyYo.ViewModels;
using ReactiveUI.XamForms;
using System.ComponentModel;
using Xamarin.Forms;

namespace HeyYo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ReactiveContentPage<MainViewModel>
    {
        public MainPage()
        {
            BindingContext = ViewModel;

            InitializeComponent();
        }

        private async void ReactiveContentPage_Appearing(object sender, System.EventArgs e)
        {
            await Title.FadeTo(1, 2000, easing: Easing.SpringIn);
        }
    }
}
