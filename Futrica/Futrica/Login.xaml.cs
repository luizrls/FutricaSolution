using Futrica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futrica.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Futrica.Services;
using System.Net.Http;
using Newtonsoft.Json;
using Futrica.Helpers;

namespace Futrica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        private readonly HttpClient _client = new HttpClient();


        //LoginViewModel vm = new LoginViewModel();
        //private readonly CustomersApiClient _customerApiClient;
        public Login()
        {
            InitializeComponent();

            FutricaLogo.Source = ImageSource.FromFile("FutricaLogo.png");

            OnAppearing();

            //this.BindingContext = new LoginViewModel();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastro());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //FutricaUsuariosServiceEx.removeAll();

            //string content = await _client.GetStringAsync(Constantes.ApiBaseURL + "Usuarios");
            //List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

            //foreach (Usuario usuario in usuarios)
            //{
            //    FutricaUsuariosServiceEx.addItem(0, usuario);
            //}

            var usuario1 = FutricaUsuariosServiceEx.TodosUsuarios.Where(x => x.login.ToLower() == loginEntry.Text.ToLower() && x.senha.ToLower() == passwordEntry.Text.ToLower()).FirstOrDefault();

            //vm.validaLogin(loginEntry.Text, passwordEntry.Text);

            //Usuario usuario = new Usuario
            //{
            //    id = 2,
            //    flgAtivo = true,
            //    login = "lsanto27",
            //    nick = "lsanto27",
            //    senha = "1234"
            //};

            if (usuario1 != null) //App.Usuario
            {
                App.Usuario = usuario1;
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

        protected override async void OnAppearing()
        {
            FutricaUsuariosServiceEx.removeAll();

            string content = await _client.GetStringAsync(Constantes.ApiBaseURL + "Usuarios");
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

            foreach (Usuario usuario in usuarios)
            {
                FutricaUsuariosServiceEx.addItem(0, usuario);
            }

            base.OnAppearing();
        }
    }
}