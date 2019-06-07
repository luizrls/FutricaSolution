using Futrica.Helpers;
using Futrica.Models;
using Futrica.Services;
using Futrica.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futrica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {

        private readonly HttpClient _client = new HttpClient();
        public Cadastro()
        {
            InitializeComponent();

            FutricaLogo.Source = ImageSource.FromFile("FutricaLogo.png");

            //this.BindingContext = new LoginViewModel();
        }

        async void OnCadastrarButtonClicked(object sender, EventArgs e)
        {
            Usuario usuario = FutricaUsuariosServiceEx.TodosUsuarios.Where(x => x.nick.ToLower() == NickEntry.Text.ToLower()).FirstOrDefault();

            if (usuario != null)
            {
                await DisplayAlert("Erro", "Login ou nick já cadastrado", "Ok");
                return;
            }

            usuario = new Usuario
            {
                senha = passwordEntry.Text,
                nick = NickEntry.Text,
                flgAtivo = true

            };

            string content = JsonConvert.SerializeObject(usuario);

            var result = await _client.PostAsync(Constantes.ApiBaseURL + "Usuarios", new StringContent(content, Encoding.UTF8, "application/json"));

            FutricaUsuariosServiceEx.addItem(0, usuario);

            await DisplayAlert("Sucesso!", "Cadastro realizado com sucesso!", "Ok");

            passwordEntry.Text = "";
            NickEntry.Text = "";
        }
    }
}