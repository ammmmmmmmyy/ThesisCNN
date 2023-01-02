using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThesisCNN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyFiles : ContentPage
    {
        public MyFiles()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        //Back button
        public ICommand GoBackCommand => new Command(async () => await Shell.Current.GoToAsync($"//{nameof(MainMenu_NoiseReduct)}"));

    }
}