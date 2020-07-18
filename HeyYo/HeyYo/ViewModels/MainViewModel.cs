using HeyYo.Core.App.Text;
using ReactiveUI;
using Splat;
using System.Windows.Input;

namespace HeyYo.ViewModels
{
    public class MainViewModel : ReactiveObject, IRoutableViewModel
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

        public string UrlPathSegment => "Main Page";

        public IScreen HostScreen { get; private set; }

        public ICommand GoToRegisterCommand { get; set; }

        public ICommand GoToLoginCommand { get; set; }

        public MainViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Title = TextNormalization.MainPageTitle;

            GoToRegisterCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new RegisterViewModel());
            });

            GoToLoginCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new LoginViewModel());
            });
        }
    }
}
