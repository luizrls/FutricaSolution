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
    public class MensagemTiposController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/MensagemTipos
        public IQueryable<MensagemTipos> GetMensagemTipos()
        {
            return db.MensagemTipos;
        }

        // GET: api/MensagemTipos/5
        [ResponseType(typeof(MensagemTipos))]
        public IHttpActionResult GetMensagemTipos(int id)
        {
            MensagemTipos mensagemTipos = db.MensagemTipos.Find(id);
            if (mensagemTipos == null)
            {
                return NotFound();
            }

            return Ok(mensagemTipos);
        }

        // PUT: api/MensagemTipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMensagemTipos(int id, MensagemTipos mensagemTipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensagemTipos.id)
            {
                return BadRequest();
            }

            db.Entry(mensagemTipos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemTiposExists(id))
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

        // POST: api/MensagemTipos
        [ResponseType(typeof(MensagemTipos))]
        public IHttpActionResult PostMensagemTipos(MensagemTipos mensagemTipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MensagemTipos.Add(mensagemTipos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mensagemTipos.id }, mensagemTipos);
        }

        // DELETE: api/MensagemTipos/5
        [ResponseType(typeof(MensagemTipos))]
        public IHttpActionResult DeleteMensagemTipos(int id)
        {
            MensagemTipos mensagemTipos = db.MensagemTipos.Find(id);
            if (mensagemTipos == null)
            {
                return NotFound();
            }

            db.MensagemTipos.Remove(mensagemTipos);
            db.SaveChanges();

            return Ok(mensagemTipos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MensagemTiposExists(int id)
        {
            return db.MensagemTipos.Count(e => e.id == id) > 0;
        }
    }
}