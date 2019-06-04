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
    public partial class Mensagens : ContentPage
    {
        private readonly HttpClient _client = new HttpClient(); //Creating a new instance of HttpClient. (Microsoft.Net.Http)

        //MensagensListViewModel vm;

        public Conversa conversa { get; set; }
        public int UsuarioId { get; set; }
        
        public Mensagens(Conversa conversa, int UsuarioId)
        {
            InitializeComponent();

            //BindingContext = vm = new MensagensListViewModel(conversa);
            //BindingContext = FutricaMensagensServiceEx.TodasMensagens.Where(x=>x.ConversaId == conversa.id);

            this.conversa = conversa;
            this.UsuarioId = UsuarioId;

            //vm.Items.CollectionChanged += (sender, e) =>
            //{
            //    var target = vm.Messages[vm.Messages.Count - 1];
            //    MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            //};
        }

        void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;

        }

        protected override async void OnAppearing()
        {
            FutricaMensagensServiceEx.removeAll();

            string content = await _client.GetStringAsync(Constantes.ApiBaseURL + "Mensagens" + "?ConversaId=" + conversa.id);
            List<Mensagen> mensagens = JsonConvert.DeserializeObject<List<Mensagen>>(content);

            foreach (Mensagen mensagen in mensagens)
            {
                FutricaMensagensServiceEx.addItem(0, mensagen);
            }

            MessagesListView.ItemsSource = FutricaMensagensServiceEx.TodasMensagens;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            Mensagen mensagen = new Mensagen
            {
                mensagem = mensagemEntry.Text,
                IsIncoming = false,
                dtEnvio = DateTime.Now,
                UsuarioId = App.Usuario.id,
                usuarioNick = App.Usuario.nick,
                ConversaId = conversa.id,
                MensagemTiposId = 1,
                flgAtivo = true,
            };

            string content = JsonConvert.SerializeObject(mensagen);
            await _client.PostAsync(Constantes.ApiBaseURL + "Mensagens", new StringContent(content, Encoding.UTF8, "application/json"));
            FutricaMensagensServiceEx.addItem(mensagen);

            mensagemEntry.Text = "";
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            Mensagen mensagen = FutricaMensagensServiceEx.TodasMensagens[0];
            mensagen.mensagem += " [updated]";
            string content = JsonConvert.SerializeObject(mensagen);
            await _client.PutAsync(Constantes.ApiBaseURL + "Mensagens" + "/" + mensagen.id, new StringContent(content, Encoding.UTF8, "application/json"));
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            Mensagen mensagen = FutricaMensagensServiceEx.TodasMensagens[0];
            await _client.DeleteAsync(Constantes.ApiBaseURL + "Mensagens" + "/" + mensagen.id);
            FutricaMensagensServiceEx.removeItem(mensagen);
        }
    }
}