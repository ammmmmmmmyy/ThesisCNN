using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu_TextToSpeech : ContentPage
    {
        public MainMenu_TextToSpeech()
        {
            InitializeComponent();
            TextToSpeech.SpeakAsync("Hello User");
        }
        //Text to Speech
        public void SpeechButtonPressed(object sender, EventArgs args)
        {
            TextToSpeech.SpeakAsync(SpeechInput.Text);
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
        private void Clicked_button_noiseReduction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_NoiseReduct());
        }
        private void Clicked_button_cam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_SignLangCapture());
        }
        private void Clicked_button_speech(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_SpeechTextTrans());
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

        //NAV:SPEECH TO TEXT PAGE
        private void Button_text_speech(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu_SpeechTextTrans());
        }
    }
}