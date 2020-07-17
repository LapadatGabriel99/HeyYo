using HeyYo.ViewModels;
using ReactiveUI.XamForms;
using System.ComponentModel;

namespace HeyYo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ReactiveContentPage<MainViewModel>
    {
        public MainPage()
        {
            BindingContext = ViewModel = new MainViewModel();

            InitializeComponent();
        }
    }
}
