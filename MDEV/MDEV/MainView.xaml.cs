using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDEV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public int LessonUrl;
        public MainView(int lesson_id,int lesson_type)
        {
            InitializeComponent();
            DependencyService.Get<IClearCache>().Clear();
            WebView webView = new WebView();
            this.Content = webView;
            if (lesson_type == 1)
                webView.Source = "https://oybekrustamov.github.io/MDEV/theory/" + lesson_id + ".html";
            else 
                webView.Source = "https://oybekrustamov.github.io/MDEV/practise/" + lesson_id + ".html";
        }
    }
}