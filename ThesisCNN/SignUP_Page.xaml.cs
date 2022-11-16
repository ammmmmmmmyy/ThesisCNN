﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_NoiseReduct());
        }
        private void TapGes_login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login_Page());
        }
    }
}