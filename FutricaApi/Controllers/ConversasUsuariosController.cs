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
    public class ConversasUsuariosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/ConversasUsuarios
        public IQueryable<ConversasUsuarioDTO> GetConversasUsuarios() => db.ConversasUsuarios.Select(x=> new ConversasUsuarioDTO {id=x.id,ConversaId = x.ConversaId,UsuarioId =x.UsuarioId });


        // GET: api/ConversasUsuarios
        public IQueryable<ConversasUsuarioDTO> GetConversasUsuarios(int UsuarioId)=> db.ConversasUsuarios.Where(x => x.UsuarioId == UsuarioId).Select(x => new ConversasUsuarioDTO { id = x.id, ConversaId = x.ConversaId, UsuarioId = x.UsuarioId });

        // GET: api/ConversasUsuarios/5
        //[ResponseType(typeof(ConversasUsuario))]
        //public IHttpActionResult GetConversasUsuario(int id)
        //{
        //    ConversasUsuario conversasUsuario = db.ConversasUsuarios.Find(id);
        //    if (conversasUsuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(conversasUsuario);
        //}

        // PUT: api/ConversasUsuarios/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutConversasUsuario(int id, ConversasUsuario conversasUsuario)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != conversasUsuario.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(conversasUsuario).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ConversasUsuarioExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/ConversasUsuarios
        [ResponseType(typeof(ConversasUsuarioDTO))]
        public IHttpActionResult PostConversasUsuario(ConversasUsuario conversasUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConversasUsuarios.Add(conversasUsuario);
            db.SaveChanges();

            ConversasUsuarioDTO conversasUsuarioDTO = new ConversasUsuarioDTO();

            conversasUsuarioDTO.id = conversasUsuarioDTO.id;
            conversasUsuarioDTO.UsuarioId = conversasUsuarioDTO.UsuarioId;
            conversasUsuarioDTO.ConversaId = conversasUsuarioDTO.ConversaId;

            return CreatedAtRoute("DefaultApi", new { id = conversasUsuarioDTO.id }, conversasUsuarioDTO);
        }

        // DELETE: api/ConversasUsuarios/5
        [ResponseType(typeof(ConversasUsuarioDTO))]
        public IHttpActionResult DeleteConversasUsuario(int id)
        {
            ConversasUsuario conversasUsuario = db.ConversasUsuarios.Find(id);
            if (conversasUsuario == null)
            {
                return NotFound();
            }

            db.ConversasUsuarios.Remove(conversasUsuario);
            db.SaveChanges();

            ConversasUsuarioDTO conversasUsuarioDTO = new ConversasUsuarioDTO();

            conversasUsuarioDTO.id = conversasUsuarioDTO.id;
            conversasUsuarioDTO.UsuarioId = conversasUsuarioDTO.UsuarioId;
            conversasUsuarioDTO.ConversaId = conversasUsuarioDTO.ConversaId;

            return Ok(conversasUsuarioDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConversasUsuarioExists(int id)
        {
            return db.ConversasUsuarios.Count(e => e.id == id) > 0;
        }
    }
}