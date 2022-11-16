using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu_NoiseReduct : ContentPage
    {
        public MainMenu_NoiseReduct()
        {
            InitializeComponent();
        }
        //SWITCH
        private void Switch_toggled(object sender, ToggledEventArgs e)
        {
            var state = e.Value;
            if (state == false)
            {
                switchState.Text = "off";
                button_low.IsEnabled = false;
                button_medium.IsEnabled = false;
                button_high.IsEnabled = false;
            }
            else
            {
                switchState.Text = "on";
                button_low.IsEnabled = true;
                button_medium.IsEnabled = true;
                button_high.IsEnabled = true;
            }
        }
        //
        private void Button_noiseReduction_low(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login_Page());
        }
        private void Button_noiseReduction_medium(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUP_Page());
        }
        private void Button_noiseReduction_high(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_NoiseReduct());
        }
        //MAIN BUTTON
        async void Button_mainmenu(object sender, EventArgs e)
        {
            if (button_noiseReduction.IsVisible == false && button_cam.IsVisible == false && button_speech.IsVisible == false)
            {
                button_noiseReduction.IsVisible = true;
                button_cam.IsVisible = true;
                button_speech.IsVisible = true;

                await Task.WhenAll(
                    button_noiseReduction.TranslateTo(0, -90, 500),
                    button_cam.TranslateTo(130, 0, 500),
                    button_speech.TranslateTo(-130, 0, 500)
                    );

                button_noiseReduction.IsEnabled = true;
                button_cam.IsEnabled = true;
                button_speech.IsEnabled = true;
            }
            else
            {
                button_noiseReduction.IsEnabled = false;
                button_cam.IsEnabled = false;
                button_speech.IsEnabled = false;

                await Task.WhenAll(
                    button_noiseReduction.TranslateTo(0, 50, 500),
                    button_cam.TranslateTo(-20, 0, 500),
                    button_speech.TranslateTo(20, 0, 500)
                    );

                button_noiseReduction.IsVisible = false;
                button_cam.IsVisible = false;
                button_speech.IsVisible = false;
            }
        }
        //MAIN MENU NOISE REDUCTION 
        private void Clicked_button_noiseReduction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_NoiseReduct());
        }
        //MAIN MENU CAM
        private void Clicked_button_cam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_SignLangCapture());
        }
        //MAIN MENU SPEECH TO TEXT
        private void Clicked_button_speech(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_TextToSpeech());
        }
        //HAMBURGER MENU
        private async void Button_HamMenu(object sender, EventArgs e)
        {
            if (HamMenu.IsEnabled == false)
            {
                HamMenu.IsEnabled = true;
                HamMenu.IsVisible = true;
                await HamMenu.TranslateTo(0, 0, 500);
            }
            else
            {
                await HamMenu.TranslateTo(-300, 0, 500);
                HamMenu.IsEnabled = false;
                HamMenu.IsVisible = false;
            }
        }
        //MY PROFILE
    }
}