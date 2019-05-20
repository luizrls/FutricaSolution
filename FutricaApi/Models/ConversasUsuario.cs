namespace FutricaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConversasUsuario
    {
        public int id { get; set; }

        public int ConversaId { get; set; }

        public int UsuarioId { get; set; }

        public virtual Conversa Conversa { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
