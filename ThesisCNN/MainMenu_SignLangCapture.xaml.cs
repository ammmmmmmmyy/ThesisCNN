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

            var urlSource = new UrlWebViewSource();

            string baseUrl = DependencyService.Get<IBaseUrl>().Get();
            string filePathUrl = Path.Combine(baseUrl, "index.html");
            urlSource.Url = filePathUrl;
            webviewjava.Source = urlSource;


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RunTimePermission();
        }

        public async void RunTimePermission()
        {
            var status = PermissionStatus.Unknown;

            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {

                status = await Utils.CheckPermissions(Permission.Camera);
            }

        }


    }
}