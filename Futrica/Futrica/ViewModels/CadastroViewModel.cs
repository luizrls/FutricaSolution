using Futrica.Helpers;
using Futrica.Models;
using Futrica.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Futrica.ViewModels
{
    class CadastroViewModel
    {
        public async void cadastrar(string nick, string login, string senha)
        {

            Usuario usuario = new Usuario
            {
                nick = nick,
                senha = senha,
                flgAtivo = true,

            };


            string loginURL = Constantes.ApiBaseURL + "Usuarios";

            Usuario usuario2 = await FutricaApiService.CallServiceAsync<Usuario>(loginURL, string.Empty, usuario, "PUT", string.Empty, string.Empty) as Usuario;

            if (usuario2 != null)
            {
                App.Usuario = usuario2;
            }

        }
    }
}
