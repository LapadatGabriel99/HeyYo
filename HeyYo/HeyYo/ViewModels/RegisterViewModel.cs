using HeyYo.Core.App.Text;
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
        }
    }
}
