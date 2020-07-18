using HeyYo.Core.App.Text;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace HeyYo.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _title;

        public string Title
        {
            get => _title;

            set
            {
                this.RaiseAndSetIfChanged(ref _title, value);
            }
        }

        public string UrlPathSegment => "Login View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToRegisterCommand { get; set; }

        public LoginViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Title = TextNormalization.LoginPageTitle;

            GoToRegisterCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new RegisterViewModel());
            });
        }
    }
}
