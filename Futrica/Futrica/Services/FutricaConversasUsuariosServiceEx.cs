using Futrica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Futrica.Services
{
    class FutricaConversasUsuariosServiceEx
    {
        public static ObservableCollection<ConversasUsuario> TodasConversasUsuarios { get; private set; }

        public FutricaConversasUsuariosServiceEx()
        {
            inicializar();
        }

        public static void addItem(ConversasUsuario conversasUsuario)
        {
            TodasConversasUsuarios.Add(conversasUsuario);
        }

        public static void addItem(int index, ConversasUsuario conversasUsuario)
        {
            TodasConversasUsuarios.Insert(index, conversasUsuario);
        }

        public static void removeItem(ConversasUsuario conversasUsuario)
        {
            TodasConversasUsuarios.Remove(conversasUsuario);
        }

        public static void removeAll()
        {
            inicializar();
        }

        private static void inicializar()
        {
            TodasConversasUsuarios = new ObservableCollection<ConversasUsuario>();
            //{
            //    new Usuario {
            //        id = 2,
            //        login = "lsanto27",
            //        nick = "lsanto27",
            //        flgAtivo = true,
            //        senha = "1234"
            //    },
            //};
        }
    }
}
