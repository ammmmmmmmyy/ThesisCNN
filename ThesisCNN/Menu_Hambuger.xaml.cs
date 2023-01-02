using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu_Hambuger : StackLayout
    {
        public Menu_Hambuger()
        {
            InitializeComponent();
        }
        //MY PROFILE
        private void Button_Myprofile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyProfile());
        }
        private void Button_Myfiles(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyFiles());
        }
        private void Button_About(object sender, EventArgs e)
        {
            Navigation.PushAsync(new About());
        }
        private void Button_Logout(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login_Page());
        }
    }
}