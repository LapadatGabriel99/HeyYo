using HeyYo.Core.App.Text;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace HeyYo.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _header;

        public string Header
        {
            get => _header;

            set
            {
                this.RaiseAndSetIfChanged(ref _header, value);
            }
        }

        private string _formButtonText;

        public string FormButtonText
        {
            get => _formButtonText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formButtonText, value);
            }
        }

        private string _formLabelText;

        public string FormLabelText
        {
            get => _formLabelText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formLabelText, value);
            }
        }

        public string UrlPathSegment => "Login View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToRegisterCommand { get; set; }

        public LoginViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            InitiateViewText();

            GoToRegisterCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new RegisterViewModel());
            });
        }

        private void InitiateViewText()
        {
            Header = TextNormalization.LoginPageHeader;

            FormButtonText = TextNormalization.LoginPageHeader;

            FormLabelText = TextNormalization.LoginPageFormLabel;
        }
    }
}
