using HeyYo.Extensions;
using HeyYo.Pages;
using HeyYo.ViewModels;
using Newtonsoft.Json.Bson;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace HeyYo
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }

        public AppBootstrapper()
        {
            Router = new RoutingState();

            RegisterScreen();
            RegisterServices();
            RegisterViewsWithViewModels();

            Router.Navigate.Execute(new MainViewModel());
        }

        private void RegisterServices()
        {

        }

        private void RegisterViewsWithViewModels()
        {
            Locator.CurrentMutable.Register(() => new MainPage().WithoutNavBar(), typeof(IViewFor<MainViewModel>));
            Locator.CurrentMutable.Register(() => new LoginPage().WithoutNavBar(), typeof(IViewFor<LoginViewModel>));
            Locator.CurrentMutable.Register(() => new RegisterPage().WithoutNavBar(), typeof(IViewFor<RegisterViewModel>));
        }

        private void RegisterScreen()
        {
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
        }

        public Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}
