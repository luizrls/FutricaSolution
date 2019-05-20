using Futrica.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Futrica.Helpers;
using Futrica.Models;
using Newtonsoft.Json;

namespace Futrica.ViewModels
{
    class LoginViewModel : MainViewModel
    {

        public async void validaLogin(string login, string senha)
        {

            string loginURL = Constantes.ApiBaseURL + "Usuarios?login=" + login + "&senha=" + senha;

            Usuario usuario = await FutricaApiService.CallServiceAsync<Usuario>(loginURL, string.Empty, null, "GET", string.Empty, string.Empty) as Usuario;

            if (usuario != null)
            {
                App.Usuario = usuario;
            }

        }
        
    }
}
