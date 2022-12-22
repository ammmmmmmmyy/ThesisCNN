﻿using System;
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
    public partial class SignUP_Page : ContentPage
    {
        public SignUP_Page()
        {
            InitializeComponent();
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
                string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactData.db");
                var db = new SQLiteConnection(dbpath);

                if (IsTableExists("Contact") == true)
                {
                    var pincodequery = db.Table<Contact>().Where(a => a.Name == createAC_namee.Text).FirstOrDefault();

                    if (pincodequery != null)
                    {
                        await DisplayAlert("Notification", "Name is Already Existing", "OK");
                    }
                    else
                    {
                        var iten = new Contact()
                        {
                            Name = createAC_namee.Text,
                            Email = createAC_email.Text,
                            Password = createAC_pass.Text
                        };
                        db.Insert(iten);
                        await DisplayAlert("Notification", "Registered!", "OK");
                        await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
                    }

                }
                else
                {
                    db.CreateTable<Contact>();
                    var item = new Contact()
                    {
                        Name = createAC_namee.Text,
                        Email = createAC_email.Text,
                        Password = createAC_pass.Text
                    };
                    db.Insert(item);
                    await DisplayAlert("Notification", "Registereddd!", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
                }
            }
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
        private void TapGes_login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login_Page());
        }
    }
}