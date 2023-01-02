using SQLite;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forgot_password : ContentPage
    {
        public Forgot_password()
        {
            InitializeComponent();
        }
        private async void Button_Reset_Pass(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
            var db = new SQLiteConnection(dbpath);

            if (string.IsNullOrEmpty(entered_email.Text))
            {
                await DisplayAlert("Notification", "Please complete the following.", "OK");
            }
            else
            {
                //SET NEW PASSWORD
                if (verified_icon.IsVisible == true)
                {
                    if (string.IsNullOrEmpty(new_pass.Text) || string.IsNullOrEmpty(confirm_pass.Text))
                    {
                        await DisplayAlert("Notification", "Please complete the following.", "OK");
                    }
                    else
                    {
                        if (new_pass.Text == confirm_pass.Text)
                        {
                            var verify_email = db.Table<Contact_loggedIn>().Where(a => a.Email == entered_email.Text).FirstOrDefault();
                            if (verify_email != null)
                            {
                                verify_email.Password = confirm_pass.Text;
                                db.Update(verify_email);
                            }
                            await DisplayAlert("Notification", "New password has been set", "OK");
                            await Shell.Current.GoToAsync($"//{nameof(Login_Page)}");
                        }
                        else
                        {
                            await DisplayAlert("Notification", "Entered password does not match", "OK");
                        }
                    }
                }
                else
                {
                    //EMAIL VERIFICATION
                    var verify_email = db.Table<Contact_loggedIn>().Where(a => a.Email == entered_email.Text).FirstOrDefault();
                    if (verify_email != null)
                    {
                        await DisplayAlert("Notification", "Email verified", "OK");
                        verified_icon.IsVisible = true;
                        pass_button_text.Text = "Reset Password";
                        entered_email.IsEnabled = false;

                        new_pass.IsEnabled = true;
                        confirm_pass.IsEnabled = true;
                    }
                    else
                    {
                        verified_icon.IsVisible = false;
                        await DisplayAlert("Notification", "Email is not registered", "OK");
                    }
                }

            }
        }
    }
}