using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_Page : ContentPage
    {
        public Login_Page()
        {
            InitializeComponent();
        }
        //REGISTRATION
        private async void Register_Clicked(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactData.db");
            var db = new SQLiteConnection(dbpath);

            if (string.IsNullOrEmpty(logIn_email.Text) || string.IsNullOrEmpty(logIn_pass.Text))
            {
                await DisplayAlert("Notification", "Please complete the following.", "OK");
            }
            else
            {
                if (IsTableExists("Contact") == true)
                {
                    //CHECKS IF THE PROVIDED EMAIL & PASSWORD EXIST
                    var pincodequery = db.Table<Contact>().Where(a => a.Email == logIn_email.Text).Where(b => b.Password == logIn_pass.Text).FirstOrDefault();
                    if (pincodequery != null)
                    {
                        await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
                    }
                    else
                    {
                        await DisplayAlert("Notification", "Account does not exist", "OK");
                    }
                }
            }
            //
            
        }
        //
        private bool IsTableExists(string v)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactData.db");
            var db = new SQLiteConnection(dbpath);
            try
            {
                var tableInfo = db.GetTableInfo("Contact");
                if (tableInfo.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //
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