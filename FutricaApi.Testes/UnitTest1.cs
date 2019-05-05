using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FutricaApi.Models;
using FutricaApi.Controllers;

namespace FutricaApi.Testes
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SelecionaUsuarios()
        {
            UsuariosController c = new UsuariosController();

            var resultado = c.GetUsuarios();
            //Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void CriarUsuario()
        {
            Usuario u = new Usuario();

            u.login = "teste3";
            u.senha = "1234";
            u.nick = "teste3";
            u.flgAtivo = true;

            UsuariosController c = new UsuariosController();

            var resultado =  c.PostUsuario(u);
            //Assert.AreEqual(true, resultado);
        }
    }
}
