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
    public partial class Hamburger_Menu_Shell : Shell
    {
        public Hamburger_Menu_Shell()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }
        private void Button_Logout(object sender, EventArgs e)
        {
            if (IsTableExists("Contact_loggedIn") == true)
            {
                string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contactDB.db");
                var db = new SQLiteConnection(dbpath);

                string contactlog_true = "true";
                var findTrue = db.Table<Contact_loggedIn>().Where(a => a.Logged_In == contactlog_true).FirstOrDefault();
                if (findTrue != null)
                {
                    findTrue.Logged_In = "false";
                    db.Update(findTrue);
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
    }
}