using HeyYo.ViewModels;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

namespace HeyYo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ReactiveContentPage<RegisterViewModel>
    {
        public RegisterPage()
        {
            BindingContext = ViewModel;

            InitializeComponent();
        }
    }
}