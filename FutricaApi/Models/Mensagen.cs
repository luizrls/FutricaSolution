namespace FutricaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mensagen
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string usuarioNick { get; set; }

        public int ConversaId { get; set; }

        public int MensagemTiposId { get; set; }

        [Required]
        [StringLength(300)]
        public string mensagem { get; set; }

        public bool flgAtivo { get; set; }

        public DateTime dtEnvio { get; set; }

        public int UsuarioId { get; set; }

        public bool IsIncoming { get; set; }

        public virtual Conversa Conversa { get; set; }

        public virtual MensagemTipos MensagemTipos { get; set; }
    }
}
