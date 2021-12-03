using Xamarin.Forms;

namespace MDEV
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI3MTc3QDMxMzkyZTMzMmUzMGZrSWVidDk3Q3hsV1NBRHhYZWpiRFpIR25lSTRGekhMSmdUSHpxN252OTQ9");
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
