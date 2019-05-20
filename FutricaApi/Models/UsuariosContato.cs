namespace FutricaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuariosContatos")]
    public partial class UsuariosContato
    {
        public int id { get; set; }

        public int UsuarioId { get; set; }

        public int contatoId { get; set; }

        public bool flgAtivo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
