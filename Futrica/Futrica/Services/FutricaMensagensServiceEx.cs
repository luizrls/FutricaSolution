using Futrica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Futrica.Services
{
    class FutricaMensagensServiceEx
    {
        public static ObservableCollection<Mensagen> TodasMensagens { get; private set; }
        /// <summary>
        /// Inicializa uma instância dessa classe populando a lista de contatos.
        /// </summary>

        public FutricaMensagensServiceEx()
        {
            inicializar();
        }

        public static void addItem(Mensagen mensagen)
        {
            mensagen.usuarioNick = mensagen.usuarioNick + " - " + mensagen.dtEnvio.ToString("dd/mm/yyyy hh:MM:ss");

            foreach (Mensagen msg in TodasMensagens)
            {
                if (msg.id == mensagen.id)
                    return;
            }

            TodasMensagens.Add(mensagen);
        }

        public static void addItem(int index, Mensagen mensagen)
        {
            mensagen.usuarioNick = mensagen.usuarioNick + " - " + mensagen.dtEnvio.ToString("dd/mm/yyyy hh:MM:ss");

            foreach (Mensagen msg in TodasMensagens)
            {
                if (msg.id == mensagen.id)
                    return;
            }

            TodasMensagens.Insert(index, mensagen);
        }

        public static void removeItem(Mensagen mensagen)
        {
            TodasMensagens.Remove(mensagen);
        }

        public static void removeAll()
        {
            inicializar();
        }

        private static void inicializar()
        {
            TodasMensagens = new ObservableCollection<Mensagen>();
            //{
            //    new Mensagen { id = 0, usuarioNick = "Joao", ConversaId = 0, MensagemTiposId = 1, mensagem = "E aí?", flgAtivo = true, dtEnvio = DateTime.Parse("2019-05-30"), UsuarioId = 1, IsIncoming = true},
            //    new Mensagen { id = 0, usuarioNick = "Zezinho", ConversaId = 0, MensagemTiposId = 1, mensagem = "Fala manooo", flgAtivo = true, dtEnvio = DateTime.Parse("2019-05-30"), UsuarioId = 2, IsIncoming = false}
            //};
        }
    }
}
