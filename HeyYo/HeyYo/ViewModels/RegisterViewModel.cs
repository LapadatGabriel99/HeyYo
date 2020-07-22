using HeyYo.Core.App.Text.Client;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace HeyYo.ViewModels
{
    public class RegisterViewModel : ReactiveObject, IRoutableViewModel
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

        private string _formUsernamePlaceholderText;

        public string FormUsernamePlaceholderText
        {
            get => _formUsernamePlaceholderText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formUsernamePlaceholderText, value);
            }
        }

        private string _formPasswordPlaceholderText;

        public string FormPasswordPlaceholderText
        {
            get => _formPasswordPlaceholderText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formPasswordPlaceholderText, value);
            }
        }

        private string _formConfirmPasswordPlaceholderText;

        public string FormConfirmPasswordPlaceholderText
        {
            get => _formConfirmPasswordPlaceholderText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formConfirmPasswordPlaceholderText, value);
            }
        }

        private string _formEmailPlaceholderText;

        public string FormEmailPlaceholderText
        {
            get => _formEmailPlaceholderText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formEmailPlaceholderText, value);
            }
        }

        private string _formPhonePlaceholderText;

        public string FormPhonePlaceholderText
        {
            get => _formPhonePlaceholderText;
            set
            {
                this.RaiseAndSetIfChanged(ref _formPhonePlaceholderText, value);
            }
        }

        public string UrlPathSegment => "Register View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToLoginCommand { get; set; }

        public RegisterViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            InitiateViewText();

            GoToLoginCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new LoginViewModel());
            });
        }

        private void InitiateViewText()
        {
            Header = TextNormalization.RegisterPageHeader;

            FormButtonText = TextNormalization.RegisterPageHeader;

            FormLabelText = TextNormalization.RegisterPageFormLabel;

            FormUsernamePlaceholderText = TextNormalization.FormUsernamePlaceholder;

            FormPasswordPlaceholderText = TextNormalization.FormPasswordPlaceholder;

            FormConfirmPasswordPlaceholderText = TextNormalization.FormConfirmPasswordPlaceholder;

            FormEmailPlaceholderText = TextNormalization.FormEmailPlaceholder;

            FormPhonePlaceholderText = TextNormalization.FormPhonePlaceholder;
        }
    }
}
