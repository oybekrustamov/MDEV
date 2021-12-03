using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MDEV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {

        int Lesson_type;

        Dictionary<int, string> theory = new Dictionary<int, string>()
        {
            {1,"Среды и языки программирования" },
            {2,"Платформа и архитектура ОС." },
            {3,"Базовые конструкции языка" },
            {4,"Классы и объекты" },
            {5,"Создание мобильных приложений" },
            {6,"Использование макетов на Android" },
            {7,"Работа с базами данных" },
            {8,"Создание запросов" },
            {9,"Определить местоположению (Geolocation) " },
            {10,"Возможности сенсора Android" },
            {11,"Типы мобильных датчиков и работа" },
            {12,"Использование сервисов Google" },
            {13,"Кросс-платформы" },
            {14,"Написание приложений для iOS" }
        };
        Dictionary<int, string> practise = new Dictionary<int, string>()
        {
            {1,"Установка и настройта среды." },
            {2,"Программирование на JAVA." },
            {3,"Создание моб. приложений" },
            {4,"Использование макетов" },
            {5,"Создание GUI Андроид" },
            {6,"Процессы и События Android" },
            {7,"Способы хранения данных" },
            {8,"Работа с базами данных" },
            {9,"Бендовое программирование. JSON " },
            {10,"Работа с геолокацией" },
            {11,"Параметры датчика Андроид" },
            {12,"Типы мобильных датчиков и работа" },
            {13,"Использование сервисов Google" },
            {14,"Кросс платформы" },
            {15,"Написание приложений для iOS" }
        };
        public MainMenu(int type)
        {
            InitializeComponent();
            Lesson_type = type;
            if (type == 1)
            {
                titleLabel.Text = "Лекционная информация";
                for (int i = 1; i <= 14; i++)
                {
                    MyButton btn = new MyButton()
                    {
                        Text = i + ". " + theory[i],
                        BackgroundColor = Color.DarkGoldenrod,
                        FontSize = 18,
                        TextColor = Color.Black,
                        HorizontalTextAlignment = TextAlignment.Start,
                        Margin = 10,
                        HeightRequest = 65,
                        CornerRadius = 10,
                        HasShadow = true,
                        LessonId = i
                    };
                    btn.Clicked += Btn_Clicked;
                    mainMenu.Children.Add(btn);
                }
            }
            else
            {
                titleLabel.Text = "Практические работы";
                for (int i = 1; i <= 15; i++)
                {
                    MyButton btn = new MyButton()
                    {
                        Text = i+". "+practise[i],
                        BackgroundColor = Color.Blue,
                        FontSize = 18,
                        HeightRequest = 60,
                        HorizontalTextAlignment = TextAlignment.Start,
                        Margin = 10,
                        CornerRadius = 10,
                        HasShadow = true,
                        LessonId = i
                    };
                    btn.Clicked += Btn_Clicked;
                    mainMenu.Children.Add(btn);
                }
            }
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            MyButton btn = sender as MyButton;            
            btn.BackgroundColor = Color.White;
            btn.TextColor = Color.Black;
            await Navigation.PushAsync(new MainView(btn.LessonId, Lesson_type));
        }
    }

    class MyButton : SfButton
    {
        public int LessonId;
    }
}