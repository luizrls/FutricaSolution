using Futrica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futrica.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futrica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        LoginViewModel vm = new LoginViewModel();
        public Login()
        {
            InitializeComponent();

            FutricaLogo.Source = ImageSource.FromFile("FutricaLogo.png");

            //this.BindingContext = new LoginViewModel();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastro());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            vm.validaLogin(loginEntry.Text, passwordEntry.Text);


            if (App.Usuario != null)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new Conversas(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }
    }
}