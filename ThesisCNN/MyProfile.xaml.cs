using SQLite;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfile : ContentPage
    {
        public MyProfile()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        //Back button
        public ICommand GoBackCommand => new Command(async () => await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}"));
        //UPDATES NAME AND EMAIL
        private async void Button_SaveChanges(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
            var db = new SQLiteConnection(dbpath);

            string changeName = $"{Application.Current.Properties["UserName"]}";
            string changeEmail = $"{Application.Current.Properties["UserEmail"]}";
            string changePass = $"{Application.Current.Properties["UserPass"]}";


            var pincodequery = db.Table<Contact_loggedIn>().Where(a => a.Email == changeEmail).Where(b => b.Password == changePass).FirstOrDefault();

            if (pincodequery != null)
            {
                if (string.IsNullOrEmpty(change_name.Text) && string.IsNullOrEmpty(change_email.Text))
                {
                    await DisplayAlert("Notification", "Please input data to update. Thank you!", "OK");
                }
                else
                {
                    if (string.IsNullOrEmpty(change_email.Text).Equals(false) && string.IsNullOrEmpty(change_name.Text).Equals(false))
                    {
                        pincodequery.Name = change_name.Text;
                        pincodequery.Email = change_email.Text;
                        db.Update(pincodequery);



                        await DisplayAlert("Notification", "Email and Name Updated.", "OK");

                        change_name.Text = null;
                        change_email.Text = null;

                    }
                    else if (string.IsNullOrEmpty(change_name.Text) && string.IsNullOrEmpty(change_email.Text).Equals(false))
                    {
                        pincodequery.Email = change_email.Text;
                        db.Update(pincodequery);

                        await DisplayAlert("Notification", "Email updated.", "OK");

                        change_name.Text = null;
                        change_email.Text = null;

                    }
                    else if (string.IsNullOrEmpty(change_email.Text) && string.IsNullOrEmpty(change_name.Text).Equals(false))
                    {
                        pincodequery.Name = change_name.Text;
                        db.Update(pincodequery);

                        await DisplayAlert("Notification", "Name Updated.", "OK");

                        change_name.Text = null;
                        change_email.Text = null;
                    }
                    await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
                }

            }

        }
    }
}