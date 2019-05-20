using FutricaApi.Models;
using FutricaApi.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FutricaApi.Controllers
{
    public class UsuariosContatosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/UsuariosContatos
        public IQueryable<UsuariosContatosDTO> GetUsuariosContatos() => db.UsuariosContatos.Select(x => new UsuariosContatosDTO { id = x.id, UsuarioId = x.UsuarioId, flgAtivo = x.flgAtivo, contatoId = x.contatoId });

        // GET: api/UsuariosContatos/5
        public IQueryable<UsuariosContatosDTO> GetUsuariosContatos(int id) => db.UsuariosContatos.Select(x => new UsuariosContatosDTO { id = x.id, UsuarioId = x.UsuarioId, flgAtivo = x.flgAtivo, contatoId = x.contatoId }).Where(x=> x.UsuarioId == id && x.flgAtivo == true);

        // POST: api/UsuariosContatos
        [ResponseType(typeof(UsuariosContatosDTO))]
        public IHttpActionResult PostUsuariosContato(UsuariosContato usuariosContato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsuariosContatos.Add(usuariosContato);
            db.SaveChanges();

            UsuariosContatosDTO usuariosContatosDTO = new UsuariosContatosDTO();

            usuariosContatosDTO.id = usuariosContato.id;
            usuariosContatosDTO.UsuarioId = usuariosContato.UsuarioId;
            usuariosContatosDTO.flgAtivo = usuariosContato.flgAtivo;
            usuariosContatosDTO.contatoId = usuariosContato.contatoId;

            return CreatedAtRoute("DefaultApi", new { id = usuariosContatosDTO.id }, usuariosContatosDTO);
        }

        // DELETE: api/UsuariosContatos/5
        [ResponseType(typeof(UsuariosContatosDTO))]
        public IHttpActionResult DeleteUsuarioContato(int id)
        {
            UsuariosContato usuarioContato = db.UsuariosContatos.Find(id);
            if (usuarioContato == null)
            {
                return NotFound();
            }

            usuarioContato.flgAtivo = false;
            db.Entry(usuarioContato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioContatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            UsuariosContatosDTO usuariosContatoDTO = new UsuariosContatosDTO();

            usuariosContatoDTO.id = usuarioContato.id;
            usuariosContatoDTO.UsuarioId = usuarioContato.UsuarioId;
            usuariosContatoDTO.flgAtivo = usuarioContato.flgAtivo;
            usuariosContatoDTO.contatoId = usuarioContato.contatoId;

            return Ok(usuariosContatoDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioContatoExists(int id)
        {
            return db.UsuariosContatos.Count(e => e.id == id) > 0;
        }
    }
}
