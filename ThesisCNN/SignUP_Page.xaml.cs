using SQLite;
using System;
using System.IO;
using System.Linq;
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
        //CHECKS IF USER IS CURRENTLY LOG IN 
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
            var db = new SQLiteConnection(dbpath);

            if (IsTableExists("Contact_loggedIn") == true)
            {
                string contactlog_true = "true";
                var findTrue = db.Table<Contact_loggedIn>().Where(a => a.Logged_In == contactlog_true).FirstOrDefault();
                if (findTrue != null)
                {
                    Application.Current.Properties["UserName"] = findTrue.Name;
                    Application.Current.Properties["UserEmail"] = findTrue.Email;
                    Application.Current.Properties["UserPass"] = findTrue.Password;

                    await Shell.Current.GoToAsync($"///{nameof(MainMenu_NoiseReduct)}");
                }

            }
        }
        private async void Register_Clicked(object sender, EventArgs e)
        {
            //
            if (string.IsNullOrEmpty(createAC_namee.Text) || string.IsNullOrEmpty(createAC_email.Text) || string.IsNullOrEmpty(createAC_pass.Text))
            {
                await DisplayAlert("Notification", "Please complete the following.", "OK");
            }
            else
            {
                string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
                var db = new SQLiteConnection(dbpath);

                if (IsTableExists("Contact_loggedIn") == true)
                {
                    var pincodequery = db.Table<Contact_loggedIn>().Where(a => a.Name == createAC_namee.Text).FirstOrDefault();

                    if (pincodequery != null)
                    {
                        await DisplayAlert("Notification", "Name is Already Existing", "OK");
                    }
                    else
                    {
                        var iten = new Contact_loggedIn()
                        {
                            Name = createAC_namee.Text,
                            Email = createAC_email.Text,
                            Password = createAC_pass.Text,
                            Logged_In = "true"
                        };
                        db.Insert(iten);
                        Application.Current.Properties["UserName"] = createAC_namee.Text;
                        Application.Current.Properties["UserEmail"] = createAC_email.Text;
                        Application.Current.Properties["UserPass"] = createAC_pass.Text;

                        createAC_namee.Text = null;
                        createAC_email.Text = null;
                        createAC_pass.Text = null;

                        await DisplayAlert("Notification", "Registered!", "OK");
                        await Navigation.PushAsync(new App_Tutorial());
                    }

                }
                else
                {
                    db.CreateTable<Contact_loggedIn>();
                    var item = new Contact_loggedIn()
                    {
                        Name = createAC_namee.Text,
                        Email = createAC_email.Text,
                        Password = createAC_pass.Text,
                        Logged_In = "true"
                    };
                    db.Insert(item);
                    Application.Current.Properties["UserName"] = createAC_namee.Text;
                    Application.Current.Properties["UserEmail"] = createAC_email.Text;
                    Application.Current.Properties["UserPass"] = createAC_pass.Text;

                    createAC_namee.Text = null;
                    createAC_email.Text = null;
                    createAC_pass.Text = null;

                    await DisplayAlert("Notification", "Registered!", "OK");
                    //await Shell.Current.GoToAsync($"//{nameof(App_Tutorial)}");
                    await Navigation.PushAsync(new App_Tutorial());
                }
            }
        }
        //
        private bool IsTableExists(string v)
        {
            string dbpath_contactLog = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
            var db_contactlog = new SQLiteConnection(dbpath_contactLog);
            try
            {
                var tableInfo = db_contactlog.GetTableInfo("Contact_loggedIn");
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
        private void TapGes_login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login_Page());
        }
    }
}