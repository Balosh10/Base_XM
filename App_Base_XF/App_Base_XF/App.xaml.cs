using System;
using App_Base_XF.ViewModel.LoginViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App_Base_XF
{
    public partial class App : Application
    {
        public static double DisplayScreenInches { get; private set; }
        public static double HeightDisplay { get; private set; }
        public static double WidthDisplay { get; private set; }
        public App()
        {
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();
            var loginPage = new LoginPage();
            loginPage.BindingContext = loginViewModel;
            MainPage = loginPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
