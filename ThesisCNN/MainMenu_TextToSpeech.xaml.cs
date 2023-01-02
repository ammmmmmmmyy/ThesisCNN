using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                    button_noiseReduction.TranslateTo(0, -90, 300),
                    button_cam.TranslateTo(130, 0, 300),
                    button_speech.TranslateTo(-130, 0, 300)
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
                    button_noiseReduction.TranslateTo(0, 50, 300),
                    button_cam.TranslateTo(-20, 0, 300),
                    button_speech.TranslateTo(20, 0, 300)
                    );

                button_noiseReduction.IsVisible = false;
                button_cam.IsVisible = false;
                button_speech.IsVisible = false;
            }
        }
        //MAIN MENU NOISE REDUCTION 
        private async void Clicked_button_noiseReduction(object sender, EventArgs e)
        {
            button_noiseReduction.IsEnabled = false;
            button_cam.IsEnabled = false;
            button_speech.IsEnabled = false;

            await Task.WhenAll(
                button_noiseReduction.TranslateTo(0, 50, 300),
                button_cam.TranslateTo(-20, 0, 300),
                button_speech.TranslateTo(20, 0, 300)
                );

            button_noiseReduction.IsVisible = false;
            button_cam.IsVisible = false;
            button_speech.IsVisible = false;

            await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
        }
        //MAIN MENU CAM
        private async void Clicked_button_cam(object sender, EventArgs e)
        {
            button_noiseReduction.IsEnabled = false;
            button_cam.IsEnabled = false;
            button_speech.IsEnabled = false;

            await Task.WhenAll(
                button_noiseReduction.TranslateTo(0, 50, 300),
                button_cam.TranslateTo(-20, 0, 300),
                button_speech.TranslateTo(20, 0, 300)
                );

            button_noiseReduction.IsVisible = false;
            button_cam.IsVisible = false;
            button_speech.IsVisible = false;

            await Shell.Current.GoToAsync($"//{nameof(MainMenu_SignLangCapture)}");
        }
        //MAIN MENU SPEECH TO TEXT
        private async void Clicked_button_speech(object sender, EventArgs e)
        {
            button_noiseReduction.IsEnabled = false;
            button_cam.IsEnabled = false;
            button_speech.IsEnabled = false;

            await Task.WhenAll(
                button_noiseReduction.TranslateTo(0, 50, 300),
                button_cam.TranslateTo(-20, 0, 300),
                button_speech.TranslateTo(20, 0, 300)
                );

            button_noiseReduction.IsVisible = false;
            button_cam.IsVisible = false;
            button_speech.IsVisible = false;

            await Shell.Current.GoToAsync($"//{nameof(MainMenu_TextToSpeech)}");
        }

        //NAV:SPEECH TO TEXT PAGE
        private async void Button_text_speech(object sender, EventArgs e)
        {
            button_noiseReduction.IsEnabled = false;
            button_cam.IsEnabled = false;
            button_speech.IsEnabled = false;

            await Task.WhenAll(
                button_noiseReduction.TranslateTo(0, 50, 300),
                button_cam.TranslateTo(-20, 0, 300),
                button_speech.TranslateTo(20, 0, 300)
                );

            button_noiseReduction.IsVisible = false;
            button_cam.IsVisible = false;
            button_speech.IsVisible = false;

            await Shell.Current.GoToAsync($"//{nameof(MainMenu_SpeechTextTrans)}");
        }
    }
}