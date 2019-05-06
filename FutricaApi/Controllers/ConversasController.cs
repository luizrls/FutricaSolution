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
    public class ConversasController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Conversas
        public IQueryable<ConversaDTO> GetConversas() => db.Conversas.Select(x => new ConversaDTO { id = x.id, UsuarioId = x.UsuarioId, nome = x.nome, flgAtivo = x.flgAtivo, flgGrupo = x.flgGrupo });

        // GET: api/Conversas
        public IQueryable<ConversaDTO> GetConversas(int UsuarioId)
        {

            var ids = db.ConversasUsuarios
            .Where(x => x.UsuarioId == UsuarioId)
            .Select(x => x.ConversaId) // extract the emails from users
            .ToList();

            return db.Conversas.Where(x => ids.Contains(x.id)).Select(x => new ConversaDTO { id = x.id, UsuarioId = x.UsuarioId, nome = x.nome, flgAtivo = x.flgAtivo, flgGrupo = x.flgGrupo });

        }

        // GET: api/Conversas/5
        //[ResponseType(typeof(Conversa))]
        //public IHttpActionResult GetConversa(int id)
        //{
        //    Conversa conversa = db.Conversas.Find(id);
        //    if (conversa == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(conversa);
        //}

        // PUT: api/Conversas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConversa(int id, Conversa conversa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conversa.id)
            {
                return BadRequest();
            }

            db.Entry(conversa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversaExists(id))
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

        // POST: api/Conversas
        [ResponseType(typeof(ConversaDTO))]
        public IHttpActionResult PostConversa(Conversa conversa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conversas.Add(conversa);
            db.SaveChanges();

            ConversasUsuario conversasUsuario = new ConversasUsuario();

            conversasUsuario.UsuarioId = conversa.UsuarioId;
            conversasUsuario.ConversaId = conversa.id;

            ConversasUsuariosController conversasUsuariosController = new ConversasUsuariosController();

            conversasUsuariosController.PostConversasUsuario(conversasUsuario);

            ConversaDTO conversaDTO = new ConversaDTO();

            conversaDTO.id = conversa.id;
            conversaDTO.UsuarioId = conversa.UsuarioId;
            conversaDTO.nome = conversa.nome;
            conversaDTO.flgAtivo = conversa.flgAtivo;
            conversaDTO.flgGrupo = conversa.flgGrupo;

            return CreatedAtRoute("DefaultApi", new { id = conversaDTO.id }, conversaDTO);
        }

        // DELETE: api/Conversas/5
        //[ResponseType(typeof(Conversa))]
        //public IHttpActionResult DeleteConversa(int id)
        //{
        //    Conversa conversa = db.Conversas.Find(id);
        //    if (conversa == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Conversas.Remove(conversa);
        //    db.SaveChanges();

        //    return Ok(conversa);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConversaExists(int id)
        {
            return db.Conversas.Count(e => e.id == id) > 0;
        }
    }
}