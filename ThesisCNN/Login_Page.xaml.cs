using SQLite;
using System;
using System.IO;
using System.Linq;
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
        //REGISTRATION
        private async void Register_Clicked(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
            var db = new SQLiteConnection(dbpath);

            if (string.IsNullOrEmpty(logIn_email.Text) || string.IsNullOrEmpty(logIn_pass.Text))
            {
                await DisplayAlert("Notification", "Please complete the following.", "OK");
            }
            else
            {
                if (IsTableExists("Contact_loggedIn") == true)
                {
                    //CHECKS IF THE PROVIDED EMAIL & PASSWORD EXIST
                    var pincodequery = db.Table<Contact_loggedIn>().Where(a => a.Email == logIn_email.Text).Where(b => b.Password == logIn_pass.Text).FirstOrDefault();
                    if (pincodequery != null)
                    {
                        pincodequery.Logged_In = "true";
                        db.Update(pincodequery);

                        string user_name = pincodequery.Name;
                        string user_email = pincodequery.Email;
                        string user_password = pincodequery.Password;
                        Application.Current.Properties["UserName"] = user_name;
                        Application.Current.Properties["UserEmail"] = user_email;
                        Application.Current.Properties["UserPass"] = user_password;


                        await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");

                        logIn_email.Text = null;
                        logIn_pass.Text = null;
                    }
                    else
                    {
                        await DisplayAlert("Notification", "Account does not exist", "OK");
                    }
                }
            }
            //

        }
        private bool IsTableExists(string v)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
            var db = new SQLiteConnection(dbpath);
            try
            {
                var tableInfo = db.GetTableInfo("Contact_loggedIn");
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
            Navigation.PushAsync(new Forgot_password());
        }
    }
}