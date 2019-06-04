using Futrica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Futrica.Services
{
    class FutricaUsuariosServiceEx
    {
        public static ObservableCollection<Usuario> TodosUsuarios { get; private set; }

        public FutricaUsuariosServiceEx()
        {
            inicializar();
        }

        public static void addItem(Usuario usuario)
        {
            TodosUsuarios.Add(usuario);
        }

        public static void addItem(int index, Usuario usuario)
        {
            TodosUsuarios.Insert(index, usuario);
        }

        public static void removeItem(Usuario usuario)
        {
            TodosUsuarios.Remove(usuario);
        }

        public static void removeAll()
        {
            inicializar();
        }

        private static void inicializar()
        {
            TodosUsuarios = new ObservableCollection<Usuario> {
                new Usuario {
                    id = 2,
                    login = "lsanto27",
                    nick = "lsanto27",
                    flgAtivo = true,
                    senha = "1234"
                },
            };
        }
    }
}
