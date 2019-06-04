using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FutricaApi.Models;

namespace FutricaApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Usuarios
        public IQueryable<UsuarioDTO> GetUsuarios() => db.Usuarios.Select(x=> new UsuarioDTO { id = x.id, nick = x.nick, flgAtivo = x.flgAtivo, login = x.login, senha = x.senha });


        // GET: api/Usuarios?login=Teste&senha=1234
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult GetUsuario(string login, string senha)
        {
            UsuarioDTO usuario = db.Usuarios.Where(x=> x.login ==  login && x.senha == senha).Select(x => new UsuarioDTO { id = x.id, nick = x.nick, flgAtivo = x.flgAtivo, login = x.login, senha = x.senha }).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuarios
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.id = usuario.id;
            usuarioDTO.nick = usuario.nick;
            usuarioDTO.flgAtivo = usuario.flgAtivo;
            usuarioDTO.login = usuario.login;

            return CreatedAtRoute("DefaultApi", new { id = usuarioDTO.id }, usuarioDTO);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(UsuarioDTO))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.flgAtivo = false;
            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.id = usuario.id;
            usuarioDTO.nick = usuario.nick;
            usuarioDTO.flgAtivo = usuario.flgAtivo;
            usuarioDTO.login = usuario.login;

            return Ok(usuarioDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.id == id) > 0;
        }
    }
}