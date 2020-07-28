using DynamicData.Binding;
using HeyYo.Core.App.String;
using HeyYo.Core.App.Text.Client;
using Newtonsoft.Json.Schema;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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

        private string _confirmPassword;

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                this.RaiseAndSetIfChanged(ref _confirmPassword, value);
            }
        }

        private string _email;

        public string Email
        {
            get => _email;
            set
            {
                this.RaiseAndSetIfChanged(ref _email, value);
            }
        }

        private string _phone;

        public string Phone
        {
            get => _phone;
            set
            {
                this.RaiseAndSetIfChanged(ref _phone, value);
            }
        }

        private readonly ObservableAsPropertyHelper<bool> _isUsernameValid;

        public bool IsUsernameValid => _isUsernameValid.Value;

        private readonly ObservableAsPropertyHelper<bool> _isPasswordValid;

        public bool IsPasswordValid => _isPasswordValid.Value;

        private readonly ObservableAsPropertyHelper<bool> _isConfirmPasswordValid;

        public bool IsConfirmPasswordValid => _isConfirmPasswordValid.Value;

        private readonly ObservableAsPropertyHelper<bool> _isEmailValid;

        public bool IsEmailValid => _isEmailValid.Value;

        private readonly ObservableAsPropertyHelper<bool> _isPhoneValid;

        public bool IsPhoneValid => _isPhoneValid.Value;

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

        private string _confirmPasswordValidationText;

        public string ConfirmPasswordValidationText
        {
            get => _confirmPasswordValidationText;
            set
            {
                this.RaiseAndSetIfChanged(ref _confirmPasswordValidationText, value);
            }
        }

        private string _emailValidationText;

        public string EmailValidationText
        {
            get => _emailValidationText;
            set
            {
                this.RaiseAndSetIfChanged(ref _emailValidationText, value);
            }
        }

        private string _phoneValidationText;

        public string PhoneValidationText
        {
            get => _phoneValidationText;
            set
            {
                this.RaiseAndSetIfChanged(ref _phoneValidationText, value);
            }
        }

        private bool _isUsernameFirstTime = true;

        private bool _isPasswordFirstTime = true;

        private bool _isConfirmPasswordFirstTime = true;

        private bool _isEmailFirstTime = true;

        private bool _isPhoneFirstTime = true;

        private bool _canExecuteSubmit;

        public bool CanExecuteSubmit
        {
            get => _canExecuteSubmit;
            set
            {
                this.RaisePropertyChanged(nameof(CanExecuteSubmit));
            }
        }

        public string UrlPathSegment => "Register View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToLoginCommand { get; set; }

        public ICommand SubmitCommand { get; set; }        

        public RegisterViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            InitiateViewText();

            GoToLoginCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new LoginViewModel());
            });

            var canExecuteSubmit = this.WhenValueChanged(viewModel => viewModel.CanExecuteSubmit)
                                   .Select(value =>
                                   {
                                       if (Username.IsNullOrEmpty() || Username.IsNullOrWhiteSpace() ||
                                           Password.IsNullOrWhiteSpace() || Password.IsNullOrEmpty() ||
                                           ConfirmPassword.IsNullOrEmpty() || ConfirmPassword.IsNullOrEmpty() ||
                                           Email.IsNullOrEmpty() || Email.IsNullOrWhiteSpace() ||
                                           Phone.IsNullOrWhiteSpace() || Phone.IsNullOrEmpty())
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

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid && IsConfirmPasswordValid && IsEmailValid && IsPhoneValid;

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

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid && IsConfirmPasswordValid && IsEmailValid && IsPhoneValid;

                    return false;
                })
                .ToProperty(this, viewModel => viewModel.IsPasswordValid, out _isPasswordValid);

            this.WhenValueChanged(viewModel => viewModel.ConfirmPassword)
                .Select(confirmPassword =>
                {
                    if (_isConfirmPasswordFirstTime)
                    {
                        _isConfirmPasswordFirstTime = false;

                        return false;
                    }

                    if (confirmPassword.IsNullOrWhiteSpace() || confirmPassword.IsNullOrEmpty())
                    {
                        ConfirmPasswordValidationText = TextValidation.ConfirmPasswordValidationMessage;

                        return true;
                    }

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid && IsConfirmPasswordValid && IsEmailValid && IsPhoneValid;

                    return false;
                })
                .ToProperty(this, viewModel => viewModel.IsConfirmPasswordValid, out _isConfirmPasswordValid);

            this.WhenValueChanged(viewModel => viewModel.Email)
                .Select(email =>
                {
                    if (_isEmailFirstTime)
                    {
                        _isEmailFirstTime = false;

                        return false;
                    }

                    if (email.IsNullOrWhiteSpace() || email.IsNullOrEmpty())
                    {
                        EmailValidationText = TextValidation.EmailValidationMessage;

                        return true;
                    }

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid && IsConfirmPasswordValid && IsEmailValid && IsPhoneValid;

                    return false;
                })
                .ToProperty(this, viewModel => viewModel.IsEmailValid, out _isEmailValid);

            this.WhenValueChanged(viewModel => viewModel.Phone)
                .Select(phone =>
                {
                    if (_isPhoneFirstTime)
                    {
                        _isPhoneFirstTime = false;

                        return false;
                    }

                    if (phone.IsNullOrEmpty() || phone.IsNullOrWhiteSpace())
                    {
                        PhoneValidationText = TextValidation.PhoneValidationMessage;

                        return true;
                    }

                    CanExecuteSubmit = IsUsernameValid && IsPasswordValid && IsConfirmPasswordValid && IsEmailValid && IsPhoneValid;

                    return false;
                })
                .ToProperty(this, viewModel => viewModel.IsPhoneValid, out _isPhoneValid);  
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

        private async Task Submit()
        {
            CanExecuteSubmit = false;

            await Task.Delay(5000);

            CanExecuteSubmit = true;
        }
    }
}
