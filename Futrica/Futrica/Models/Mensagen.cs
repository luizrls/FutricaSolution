namespace Futrica.Models
{
    using System;

    public partial class Mensagen
    {
        public int id { get; set; }

        public string usuarioNick { get; set; }

        public int ConversaId { get; set; }

        public int MensagemTiposId { get; set; }

        public string mensagem { get; set; }

        public bool flgAtivo { get; set; }

        public DateTime dtEnvio { get; set; }

        public int UsuarioId { get; set; }

        public virtual Conversa Conversa { get; set; }

        public virtual MensagemTipos MensagemTipos { get; set; }
    }
}
