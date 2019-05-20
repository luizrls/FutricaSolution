using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutricaApi.ModelsDTO
{
    public class UsuariosContatosDTO
    {
        public int id { get; set; }

        public int UsuarioId { get; set; }

        public int contatoId { get; set; }

        public bool flgAtivo { get; set; }
    }
}