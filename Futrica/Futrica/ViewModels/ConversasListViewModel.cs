using System.Collections.Generic;
using System.Linq;
using Futrica.Helpers;
using Futrica.Models;
using Futrica.Services;


namespace Futrica.ViewModels
{
    class ConversasListViewModel
    {
        //define a fonte do listview e a quantidade de itens a ser exibida no rodape
        public IList<Conversa> Items { get; private set; }
        public int ItemsCount { get; private set; }
        //define o telefone a ser exibido na view (não existe no model)
        public string Conversas { get; private set; } = "Lista de Conversas";
        //construtor
        public ConversasListViewModel()
        {
            //var repo = new FutricaConversasServiceEx();
            //Items = repo.TodasConversas.OrderBy(c => c.nome).ToList();
            //ItemsCount = repo.TodasConversas.Count;

            //getConversas();

        }

        public async void getConversas()
        {

            string loginURL = Constantes.ApiBaseURL + "Conversas?id=" + App.Usuario.id;

            var conversas = await FutricaApiService.CallServiceAsync<List<Conversa>>(loginURL, string.Empty, null, "GET", string.Empty, string.Empty) as List<Conversa>;

            Items = conversas?.ToList();
        }

    }


        
}
