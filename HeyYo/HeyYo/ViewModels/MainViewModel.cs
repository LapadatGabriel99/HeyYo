using HeyYo.Core.App.Text.Client;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace HeyYo.ViewModels
{
    public class MainViewModel : ReactiveObject, IRoutableViewModel
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

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                this.RaiseAndSetIfChanged(ref _title, value);
            }
        }

        private string _registerLabelText;

        public string RegisterLabelText
        {
            get => _registerLabelText;
            set
            {
                this.RaiseAndSetIfChanged(ref _registerLabelText, value);
            }
        }

        private string _registerButtonText;

        public string RegisterButtonText
        {
            get => _registerButtonText;
            set
            {
                this.RaiseAndSetIfChanged(ref _registerButtonText, value);
            }
        }

        private string _loginLabelText;

        public string LoginLabelText
        {
            get => _loginLabelText;
            set
            {
                this.RaiseAndSetIfChanged(ref _loginLabelText, value);
            }
        }

        public string _loginButtonText;

        public string LoginButtonText
        {
            get => _loginButtonText;
            set
            {
                this.RaiseAndSetIfChanged(ref _loginButtonText, value);
            }
        }

        private bool _titleShouldAnimate = false;

        public bool TitleShouldAnimate
        {
            get => _titleShouldAnimate;
            set
            {
                this.RaiseAndSetIfChanged(ref _titleShouldAnimate, value);
            }
        }

        public string UrlPathSegment => "Main Page";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToRegisterCommand { get; set; }

        public ICommand GoToLoginCommand { get; set; }

        // NOTE: This command is made only for testing, should be removed later
        public ICommand TestCommand { get; set; }

        public MainViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            InitiateViewText();

            GoToRegisterCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new RegisterViewModel());
            });

            GoToLoginCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new LoginViewModel());
            });

            TestCommand = ReactiveCommand.Create(() => TitleShouldAnimate = true);
        }

        private void InitiateViewText()
        {
            Header = TextNormalization.MainPageHeader;

            Title = TextNormalization.MainPageTitle;

            RegisterLabelText = TextNormalization.MainPageRegisterLabel;

            RegisterButtonText = TextNormalization.MainPageRegisterButton;

            LoginLabelText = TextNormalization.MainPageLoginLabel;

            LoginButtonText = TextNormalization.MainPageLoginButton;
        }
    }
}
