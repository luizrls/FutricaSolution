using Futrica.Models;
using Futrica.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Futrica.ViewModels
{
    class MensagensListViewModel
    {

        public Conversa conversa { get; set; }

        //define a fonte do listview e a quantidade de itens a ser exibida no rodape
        public IList<Mensagen> Items { get; private set; }
        public int ItemsCount { get; private set; }
        //define o telefone a ser exibido na view (não existe no model)
        public string Conversas { get; private set; } = "Lista de Mensagens";

        string outgoingText = string.Empty;

        //public string OutGoingText
        //{
        //    get { return outgoingText; }
        //    set { SetProperty(ref outgoingText, value); }
        //}

        //construtor
        public MensagensListViewModel(Conversa conversa)
        {

            //this.conversa = conversa;

            //var repo = new FutricaMensagensServiceEx();
            //Items = repo.TodasMensagens.OrderBy(c => c.dtEnvio).ToList();
            //ItemsCount = repo.TodasMensagens.Count;


            //SendCommand = new Command(() =>
            //{
            //    var message = new Mensagen
            //    {
            //        id = 0,
            //        usuarioNick = "Joao",
            //        ConversaId = 0,
            //        MensagemTiposId = 1,
            //        mensagem = "E aí?",
            //        flgAtivo = true,
            //        dtEnvio = DateTime.Now,
            //        UsuarioId = 1,
            //        IsIncoming = false
            //    };

            //    repo.TodasMensagens.Add(message);

            //    //twilioMessenger?.SendMessage(message.Text);

            //    //OutGoingText = string.Empty;
            //});

        }


        public ICommand SendCommand { get; set; }



    }
}
