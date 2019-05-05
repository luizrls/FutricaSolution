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
    public class MensagensController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Mensagens
        public IQueryable<Mensagen> GetMensagens()
        {
            return db.Mensagens;
        }

        // GET: api/Mensagens
        public IQueryable<Mensagen> GetMensagens(int ConversaId, DateTime DtUltimaAtualiz)
        {
            return db.Mensagens.Where(x => x.flgAtivo == true && x.ConversaId == ConversaId && x.dtEnvio >= DtUltimaAtualiz);
        }

        // GET: api/Mensagens/5
        //[ResponseType(typeof(Mensagen))]
        //public IHttpActionResult GetMensagen(int id)
        //{
        //    Mensagen mensagen = db.Mensagens.Find(id);
        //    if (mensagen == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(mensagen);
        //}

        // PUT: api/Mensagens/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMensagen(int id, Mensagen mensagen)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != mensagen.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(mensagen).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MensagenExists(id))
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

        // POST: api/Mensagens
        [ResponseType(typeof(Mensagen))]
        public IHttpActionResult PostMensagen(Mensagen mensagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mensagens.Add(mensagen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mensagen.id }, mensagen);
        }

        // DELETE: api/Mensagens/5
        [ResponseType(typeof(Mensagen))]
        public IHttpActionResult DeleteMensagen(int id, int UsuarioId)
        {
            Mensagen mensagen = db.Mensagens.Find(id);
            if (mensagen == null)
            {
                return NotFound();
            }

            if (mensagen.UsuarioId == UsuarioId)
            {
                mensagen.mensagem = "Mensagem apagada";
                mensagen.MensagemTiposId = 2;
                db.Entry(mensagen).State = EntityState.Modified;
            }
            else
            {
                return BadRequest();
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(mensagen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensagenExists(int id)
        {
            return db.Mensagens.Count(e => e.id == id) > 0;
        }
    }
}