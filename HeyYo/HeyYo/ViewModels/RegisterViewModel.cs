using HeyYo.Core.App.Text;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace HeyYo.ViewModels
{
    public class RegisterViewModel : ReactiveObject, IRoutableViewModel
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

        public string UrlPathSegment => "Register View";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToLoginCommand { get; set; }

        public RegisterViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Title = TextNormalization.RegisterPageTitle;

            GoToLoginCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new LoginViewModel());
            });
        }
    }
}
