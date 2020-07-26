using DynamicData.Binding;
using HeyYo.Core.App.String;
using HeyYo.Core.App.Text.Client;
using ReactiveUI;
using Splat;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Threading.Tasks;
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

        private readonly ObservableAsPropertyHelper<bool> _isUsernameValid;

        public bool IsUsernameValid => _isUsernameValid.Value;

        private readonly ObservableAsPropertyHelper<bool> _isPasswordValid;

        public bool IsPasswordValid => _isPasswordValid.Value;

        private string _usernameValidationText;

        public string UsernameValidationText
        {
            get => _usernameValidationText;
            set
            {
                this.RaiseAndSetIfChanged(ref _usernameValidationText, value);
            }
        }

        private string _passwordValidationText;

        public string PasswordValidationText
        {
            get => _passwordValidationText;
            set
            {
                this.RaiseAndSetIfChanged(ref _passwordValidationText, value);
            }
        }

        private bool _isUsernameFirstTime = true;

        private bool _isPasswordFirstTime = true;

        private bool _canExecuteSubmit;

        public bool CanExecuteSubmit
        {
            get => _canExecuteSubmit;
            set
            {
                this.RaisePropertyChanged(nameof(CanExecuteSubmit));
            }
        }

        public string UrlPathSegment => "Login View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToRegisterCommand { get; set; }

        public ICommand SubmitCommand { get; set; }

        public LoginViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            InitiateViewText();

            GoToRegisterCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new RegisterViewModel());
            });

            var canExecuteSubmit = this.WhenValueChanged(viewModel => viewModel.CanExecuteSubmit)
                                    .Select(value =>
                                    {
                                        if (Username.IsNullOrEmpty() || Username.IsNullOrWhiteSpace() ||
                                            Password.IsNullOrWhiteSpace() || Password.IsNullOrEmpty())
                                        {
                                            return false;
                                        }

                                        return true;
                                    });

            SubmitCommand = ReactiveCommand.CreateFromTask(Submit, canExecuteSubmit);

            this.WhenValueChanged(viewModel => viewModel.Username)
                .Select(username =>
                {
                    if (_isUsernameFirstTime)
                    {                        
                        _isUsernameFirstTime = false;

                        return false;
                    }

                    if (username.IsNullOrEmpty() || username.IsNullOrWhiteSpace())
                    {
                        UsernameValidationText = TextValidation.UsernameValidationMessage;

                        return true;
                    }

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid;

                    return false;
                })
                .ToProperty(this, viewModel => viewModel.IsUsernameValid, out _isUsernameValid);

            this.WhenValueChanged(viewModel => viewModel.Password)
                .Select(password =>
                {
                    if (_isPasswordFirstTime)
                    {
                        _isPasswordFirstTime = false;

                        return false;
                    }

                    if (password.IsNullOrWhiteSpace() || password.IsNullOrEmpty())
                    {
                        PasswordValidationText = TextValidation.PasswordValidationMessage;

                        return true;
                    }

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid;

                    return false;
                })
                .ToProperty(this, viewModel => viewModel.IsPasswordValid, out _isPasswordValid);
        }

        private void InitiateViewText()
        {
            Header = TextNormalization.LoginPageHeader;

            FormButtonText = TextNormalization.LoginPageHeader;

            FormLabelText = TextNormalization.LoginPageFormLabel;

            FormUsernamePlaceholderText = TextNormalization.FormUsernamePlaceholder;

            FormPasswordPlaceholderText = TextNormalization.FormPasswordPlaceholder;
        }

        private async Task Submit()
        {
            CanExecuteSubmit = false;

            await Task.Delay(5000);

            CanExecuteSubmit = true;

            // TODO add client service that consumes an api that calls endpoint on the web            
        }
    }
}
