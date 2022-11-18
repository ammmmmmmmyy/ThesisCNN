﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        //Back button
        public ICommand GoBackCommand => new Command(async () => await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}"));
        
    }
}