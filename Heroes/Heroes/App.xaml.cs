using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Heroes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //NavigationPage cambia el main page a un navigation page
            //es decir, podra navegar entre pantallas (navegacion push)
            MainPage = new NavigationPage (new MainPage());
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
