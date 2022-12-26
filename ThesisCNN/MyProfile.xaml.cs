using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using SQLite;
using System.IO;

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
        //
        private async void Button_SaveChanges(object sender, EventArgs e)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactData.db");
            var db = new SQLiteConnection(dbpath);

            string changeName = $"{Application.Current.Properties["UserName"]}";
            string changeEmail = $"{Application.Current.Properties["UserEmail"]}";
            string changePass = $"{Application.Current.Properties["UserPass"]}";


            var pincodequery = db.Table<Contact>().Where(a => a.Email == changeEmail).Where(b => b.Password == changePass).FirstOrDefault();

            if (pincodequery != null)
            {
                pincodequery.Name = change_name.Text;
                db.Update(pincodequery);
                await DisplayAlert("Notification", "df.", "OK");
                nameaaa.Text = pincodequery.Name;
            }

        }
    }
}