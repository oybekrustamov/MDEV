using System;
using Xamarin.Forms;
using System.IO;

namespace MDEV
{
    public partial class MainPage : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
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

        async void latest_Score_Tapped(object sender,EventArgs e)
        {
            await DisplayAlert("Информация", "Это показатель вашей последней оценки на тестирование.", "ОК");
        }
        protected override void OnAppearing()
        {
            Check_Score();
        }

        private void Check_Score()
        {
            try
            {
                StreamReader read = new StreamReader(folderPath+"/mdev_score");
                latest_Score.Text = read.ReadLine()+" балл";
                read.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
