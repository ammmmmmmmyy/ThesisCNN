using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;


namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu_SignLangCapture : ContentPage
    {
        public MainMenu_SignLangCapture()
        {
            InitializeComponent();
        }
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
            await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}");
        }
        //MAIN MENU CAM
        private async void Clicked_button_cam(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainMenu_SignLangCapture)}");
        }
        //MAIN MENU SPEECH TO TEXT
        private async void Clicked_button_speech(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainMenu_TextToSpeech)}");
        }
        //CAMERA 
        private void CaptureImage(object sender, EventArgs e)
        {
            xctCameraView.Shutter();
        }
        private void RecordVideo(object sender, EventArgs e)
        {
            xctCameraView.Shutter();
        }
        private void StopVideo(object sender, EventArgs e)
        {
            xctCameraView.Shutter();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (xctCameraView.CaptureMode == CameraCaptureMode.Photo)
            {
                captureMode.Text = "Video";
                xctCameraView.CaptureMode = CameraCaptureMode.Video;

                captureBtn.IsEnabled = false;
                btnrecordVideo.IsEnabled = true;
                btnstopVideo.IsEnabled = false;
            }
            else
            {
                captureMode.Text = "Photo";
                xctCameraView.CaptureMode = CameraCaptureMode.Photo;

                captureBtn.IsEnabled = true;
                btnrecordVideo.IsEnabled = false;
                btnstopVideo.IsEnabled = false;
            }
        }

        private void MediaCaptured(object sender, MediaCapturedEventArgs e)
        {

            imgView.Source = e.Image;
            imgViewPanel.IsVisible = true;
        }

        private void CloseImageView(object sender, EventArgs e)
        {
            imgViewPanel.IsVisible = false;
        }

    }
}