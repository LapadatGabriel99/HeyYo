using HeyYo.Core.App.Text.Client;
using ReactiveUI;
using Splat;
using System.Windows.Input;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;

namespace HeyYo.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel, IValidatableViewModel
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

        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                this.RaiseAndSetIfChanged(ref _username, value);
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                this.RaiseAndSetIfChanged(ref _password, value);
            }
        }

        public string UrlPathSegment => "Login View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToRegisterCommand { get; set; }

        public ValidationContext ValidationContext => new ValidationContext();

        public LoginViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            InitiateViewText();

            GoToRegisterCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new RegisterViewModel());
            });

            this.ValidationRule(viewModel => viewModel.Username,
                                property => string.IsNullOrEmpty(property) || string.IsNullOrWhiteSpace(property),
                                TextValidation.UsernameValidationMessage);

            this.ValidationRule(viewModel => viewModel.Password,
                                property => string.IsNullOrWhiteSpace(property) || string.IsNullOrWhiteSpace(property),
                                TextValidation.PasswordValidationMessage);

            var isValid =  this.IsValid();
        }

        private void InitiateViewText()
        {
            Header = TextNormalization.LoginPageHeader;

            FormButtonText = TextNormalization.LoginPageHeader;

            FormLabelText = TextNormalization.LoginPageFormLabel;

            FormUsernamePlaceholderText = TextNormalization.FormUsernamePlaceholder;

            FormPasswordPlaceholderText = TextNormalization.FormPasswordPlaceholder;
        }
    }
}
