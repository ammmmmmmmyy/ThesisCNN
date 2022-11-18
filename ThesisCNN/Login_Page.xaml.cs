using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_Page : ContentPage
    {
        public Login_Page()
        {
            InitializeComponent();
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
        }
        private void tapGes_signUp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUP_Page());
        }
        private void tapGes_forgotPass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUP_Page());
        }
    }
}