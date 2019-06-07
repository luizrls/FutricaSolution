using Futrica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futrica.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Futrica.Helpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Futrica.Services;

namespace Futrica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conversas : ContentPage
    {
        private readonly HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)

        private bool ativarLoop = false;

        public Conversas()
        {
            InitializeComponent();
            // BindingContext = new ConversasListViewModel();
            BindingContext = FutricaConversasServiceEx.TodasConversas;

            

        }

        async void OnContatosButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contatos(App.Usuario.id));
        }

        //async void OnMensagensButtonClicked(object sender, EventArgs e)
        //{
        //    //await Navigation.PushAsync(new Mensagens(0,0));
        //}

        public async void lvItemTapped(object sender, ItemTappedEventArgs e)
        {

            var Conversa = e.Item as Conversa;

            //var myListView = (ListView)sender;
            //var myItem = myListView.SelectedItem;
            //await DisplayAlert("Item Tocado (Item) ", Conversa.nome, "Ok");
            await Navigation.PushAsync(new Mensagens(Conversa, App.Usuario.id));
        }

        private void ConversasListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            ativarLoop = true;
            getConversas();

            //FutricaConversasUsuariosServiceEx.removeAll();

            //_client.Timeout = TimeSpan.FromSeconds(Constantes.timeoutSeconds);

            //string content = await _client.GetStringAsync(Constantes.ApiBaseURL + "ConversasUsuarios");
            //List<ConversasUsuario> conversasUsuarios = JsonConvert.DeserializeObject<List<ConversasUsuario>>(content);
            //List<int> ids = new List<int>();

            //foreach (ConversasUsuario conversasUsuario in conversasUsuarios)
            //{
            //    FutricaConversasUsuariosServiceEx.addItem(0, conversasUsuario);

            //    if (conversasUsuario.UsuarioId == App.Usuario.id)
            //    {
            //        ids.Add(conversasUsuario.ConversaId);
            //    }

            //}

            //FutricaConversasServiceEx.removeAll();

            //_client.Timeout = TimeSpan.FromSeconds(Constantes.timeoutSeconds);

            //content = await _client.GetStringAsync(Constantes.ApiBaseURL + "Conversas"); 
            //List<Conversa> conversas = JsonConvert.DeserializeObject<List<Conversa>>(content); 

            //foreach (Conversa conversa in conversas)
            //{
            //    FutricaConversasServiceEx.addItem(0, conversa);
            //}

            //ConversasListView.ItemsSource = FutricaConversasServiceEx.TodasConversas.Where(x=> ids.Contains(x.id));

            //base.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            ativarLoop = false;
        }

        private async void getConversas()
        {

            if (ConversasListView.ItemsSource == null)
            {
                FutricaConversasUsuariosServiceEx.removeAll();
                FutricaConversasServiceEx.removeAll();
                ConversasListView.ItemsSource = FutricaConversasServiceEx.TodasConversas;
            }

            _client.Timeout = TimeSpan.FromSeconds(Constantes.timeoutSeconds);

            string content = await _client.GetStringAsync(Constantes.ApiBaseURL + "ConversasUsuarios");
            List<ConversasUsuario> conversasUsuarios = JsonConvert.DeserializeObject<List<ConversasUsuario>>(content);
            List<int> ids = new List<int>();

            foreach (ConversasUsuario conversasUsuario in conversasUsuarios)
            {
                FutricaConversasUsuariosServiceEx.addItem(0, conversasUsuario);

                if (conversasUsuario.UsuarioId == App.Usuario.id)
                {
                    ids.Add(conversasUsuario.ConversaId);
                }

            }

            _client.Timeout = TimeSpan.FromSeconds(Constantes.timeoutSeconds);

            content = await _client.GetStringAsync(Constantes.ApiBaseURL + "Conversas");
            List<Conversa> conversas = JsonConvert.DeserializeObject<List<Conversa>>(content);

            foreach (Conversa conversa in conversas.Where(x => ids.Contains(x.id)))
            {
                FutricaConversasServiceEx.addItem(0, conversa);
            }

            if (ativarLoop)
            {
                Device.StartTimer(TimeSpan.FromSeconds(90), () =>
                {
                    getConversas();
                    return true;
                });
            }
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            Conversa conversa = new Conversa
            { nome = "Nova Conversa",
              flgAtivo = true,
              flgGrupo = false
            };

            _client.Timeout = TimeSpan.FromSeconds(Constantes.timeoutSeconds);

            string content = JsonConvert.SerializeObject(conversa); 
            await _client.PostAsync(Constantes.ApiBaseURL + "Conversas", new StringContent(content, Encoding.UTF8, "application/json"));
            FutricaConversasServiceEx.addItem(0, conversa); 
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            Conversa conversa = FutricaConversasServiceEx.TodasConversas[0]; 
            conversa.nome += " [updated]";
            string content = JsonConvert.SerializeObject(conversa); 
            await _client.PutAsync(Constantes.ApiBaseURL + "Conversas" + "/" + conversa.id, new StringContent(content, Encoding.UTF8, "application/json"));
        }

        private async void OnDelete(object sender, EventArgs e)
        {

            _client.Timeout = TimeSpan.FromSeconds(Constantes.timeoutSeconds);

            Conversa conversa = FutricaConversasServiceEx.TodasConversas[0];
            await _client.DeleteAsync(Constantes.ApiBaseURL + "Conversas" + "/" + conversa.id);
            FutricaConversasServiceEx.removeItem(conversa);
        }

        private async void OnContatoAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contatos(App.Usuario.id));
        }

    }
}