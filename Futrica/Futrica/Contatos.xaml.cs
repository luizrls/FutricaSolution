using Futrica.Helpers;
using Futrica.Models;
using Futrica.Services;
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
    public partial class Contatos : ContentPage
    {

        private readonly HttpClient _client = new HttpClient();

        private int usuarioId;
        public Contatos(int usuarioId)
        {
            InitializeComponent();

            this.usuarioId = usuarioId;

        }

        private async void OnAdd(object sender, EventArgs e)
        {

            Usuario usuario = FutricaUsuariosServiceEx.TodosUsuarios.Where(x => x.nick.ToLower() == ContatoEntry.Text.ToLower() && x.flgAtivo == true).FirstOrDefault();

            if (usuario == null)
            {
                await DisplayAlert("Erro", "Usuário Não encontrado", "Ok");
                return;
            }

            if (usuario.id == App.Usuario.id)
            {
                await DisplayAlert("Erro", "Não é possível adicionar você como contato", "Ok");
                return;
            }

            List<ConversasUsuario> conversasUsuarioLista = FutricaConversasUsuariosServiceEx.TodasConversasUsuarios.Where(x => x.UsuarioId == App.Usuario.id).ToList();

            List<int> idList = new List<int>();

            foreach (ConversasUsuario  item in conversasUsuarioLista)
            {
                idList.Add(item.ConversaId);
            }

            ConversasUsuario conversasUsuario = FutricaConversasUsuariosServiceEx.TodasConversasUsuarios.Where(x => idList.Contains(x.ConversaId) && x.UsuarioId == usuario.id).FirstOrDefault();

            if (conversasUsuario != null)
            {
                await DisplayAlert("Erro", "Contato já adicionado", "Ok");
                return;
            }

            Conversa conversa = new Conversa
            {
                flgAtivo = true,
                UsuarioId = App.Usuario.id,
                flgGrupo = false,
                nome = "Conversa com " + usuario.nick
            };

            string content = JsonConvert.SerializeObject(conversa);
 
            var result = await _client.PostAsync(Constantes.ApiBaseURL + "Conversas", new StringContent(content, Encoding.UTF8, "application/json"));

            if (result != null)
            {
                var jsonString = await result.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Conversa>(jsonString);

                FutricaConversasServiceEx.addItem(0, model);

                ConversasUsuario conversasUsuario1 = new ConversasUsuario()
                {
                    ConversaId = model.id,
                    UsuarioId = App.Usuario.id
                };

                content = JsonConvert.SerializeObject(conversasUsuario1);
                await _client.PostAsync(Constantes.ApiBaseURL + "ConversasUsuarios", new StringContent(content, Encoding.UTF8, "application/json"));

                FutricaConversasUsuariosServiceEx.addItem(conversasUsuario1);

                ConversasUsuario conversasUsuario2 = new ConversasUsuario()
                {
                    ConversaId = model.id,
                    UsuarioId = usuario.id
                };

                content = JsonConvert.SerializeObject(conversasUsuario2);
                await _client.PostAsync(Constantes.ApiBaseURL + "ConversasUsuarios", new StringContent(content, Encoding.UTF8, "application/json"));

                FutricaConversasUsuariosServiceEx.addItem(conversasUsuario2);

                await DisplayAlert("Sucesso", "Contato registrado com sucesso!", "Ok");
            }

        }
    }
}