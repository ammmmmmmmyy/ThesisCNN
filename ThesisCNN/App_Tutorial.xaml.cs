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
    public partial class App_Tutorial : ContentPage
    {
        public App_Tutorial()
        {
            InitializeComponent();

            List<Image> images = new List<Image>()
            { 
                new Image(){Title="Image 1", Url="n0.png"},
                new Image(){Title="Image 2", Url="n1.png"},
                new Image(){Title="Image 3", Url="n2.png"},
                new Image(){Title="Image 4", Url="n3.png"},
                new Image(){Title="Image 5", Url="n4.png"},
                new Image(){Title="Image 6", Url="n5.png"},
                new Image(){Title="Image 7", Url="n6.png"},
                new Image(){Title="Image 8", Url="n7.png"},
                new Image(){Title="Image 9", Url="n8.png"},
                new Image(){Title="Image 10", Url="n9.png"}
            };
            Carousel.ItemsSource=images;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"///{nameof(MainMenu_NoiseReduct)}");
        }
    }
}