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
        public IQueryable<ConversasUsuario> GetConversasUsuarios() => db.ConversasUsuarios;


        // GET: api/ConversasUsuarios
        public IQueryable<ConversasUsuario> GetConversasUsuarios(int UsuarioId)
        {
            return db.ConversasUsuarios.Where(x=> x.UsuarioId==UsuarioId);
        }

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
        [ResponseType(typeof(ConversasUsuario))]
        public IHttpActionResult PostConversasUsuario(ConversasUsuario conversasUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConversasUsuarios.Add(conversasUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conversasUsuario.id }, conversasUsuario);
        }

        // DELETE: api/ConversasUsuarios/5
        [ResponseType(typeof(ConversasUsuario))]
        public IHttpActionResult DeleteConversasUsuario(int id)
        {
            ConversasUsuario conversasUsuario = db.ConversasUsuarios.Find(id);
            if (conversasUsuario == null)
            {
                return NotFound();
            }

            db.ConversasUsuarios.Remove(conversasUsuario);
            db.SaveChanges();

            return Ok(conversasUsuario);
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