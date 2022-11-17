using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Hamburger_Menu_Shell();
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
