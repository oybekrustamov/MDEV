using System;
using Xamarin.Forms;

namespace MDEV
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_logo_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Информация об авторе", "Рустамов Ойбек\n913-18 / Ургенчский филиал ТУИТ\nt.me/ibektillo", "Спасибо!");
        }

        private async void btn_practise_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenu(2));
        }

        private async void btn_theory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenu(1));
        }

        private async void btn_test_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestPage());
        }
    }
}
