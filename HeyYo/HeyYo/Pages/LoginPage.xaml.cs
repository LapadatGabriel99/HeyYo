using HeyYo.ViewModels;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

namespace HeyYo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ReactiveContentPage<LoginViewModel>
    {
        public LoginPage()
        {
            BindingContext = ViewModel;

            InitializeComponent();
        }
    }
}