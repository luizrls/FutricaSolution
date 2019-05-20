using Futrica.Models;
using Futrica.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futrica
{
    public partial class App : Application
    {
        LoginViewModel vm = new LoginViewModel();
        public static bool IsUserLoggedIn { get; set; }
        public static Usuario Usuario { get; set; }

        public App()
        {
            InitializeComponent();

            //vm.validaLogin(loginEntry.Text, passwordEntry.Text);

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new NavigationPage(new Conversas());
            }
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
