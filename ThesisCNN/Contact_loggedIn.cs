using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ThesisCNN
{
    public class Contact_loggedIn
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string Logged_In
        {
            get;
            set;
        }
    }
}
