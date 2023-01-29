using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ThesisCNN
{
    public interface IBaseUrl { string Get(); }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu_SignLangCapture : ContentPage
    {
        public MainMenu_SignLangCapture()
        {
            InitializeComponent();

            /*var urlSource = new UrlWebViewSource();

            string baseUrl = DependencyService.Get<IBaseUrl>().Get();
            string filePathUrl = Path.Combine(baseUrl, "index.html");
            urlSource.Url = filePathUrl;
            webviewjava.Source = urlSource;*/
            webView.Source = "https://signit-translator.glitch.me/";

        }

        /*private void _button_Clicked(object sender, EventArgs e)
        {
            webView.Source = "https://signit-translator-from-chatgpt.glitch.me/";
        }*/

    }
}