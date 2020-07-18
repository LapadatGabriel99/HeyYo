using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeyYo
{
    public partial class App : Application
    {
        public AppBootstrapper AppBootstrapper { get; set; }

        public App()
        {
            InitializeComponent();

            AppBootstrapper = new AppBootstrapper();

            MainPage = AppBootstrapper.CreateMainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
