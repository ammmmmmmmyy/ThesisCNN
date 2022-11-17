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
    public partial class SignUP_Page : ContentPage
    {
        public SignUP_Page()
        {
            InitializeComponent();
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
        }
        private void TapGes_login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login_Page());
        }
    }
}