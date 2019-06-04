using Futrica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Futrica.Services
{
    class FutricaConversasServiceEx
    {
        public static ObservableCollection<Conversa> TodasConversas { get; private set; }

        public FutricaConversasServiceEx()
        {
            inicializar();
        }

        public static void addItem(Conversa conversa)
        {
            TodasConversas.Add(conversa);
        }

        public static void addItem(int index, Conversa conversa)
        {
            TodasConversas.Insert(index,conversa);
        }

        public static void removeItem(Conversa conversa)
        {
            TodasConversas.Remove(conversa);
        }

        public static void removeAll()
        {
            inicializar();
        }

        private static void inicializar()
        {
            TodasConversas = new ObservableCollection<Conversa>();
            //{
            //    new Conversa { id = 0, nome = "Conversa com João", UsuarioId = 1, flgAtivo = true, flgGrupo = true},
            //    new Conversa { id = 0, nome = "Conversa com Maria", UsuarioId = 1, flgAtivo = true, flgGrupo = true}
            //};
        }

    }
}
