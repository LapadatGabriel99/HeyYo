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
        }

        private void RegisterServices()
        {

        }

        private void RegisterViewsWithViewModels()
        {

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
