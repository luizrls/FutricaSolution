namespace Futrica.Models
{
    using System;
    using System.Collections.Generic;


    public partial class ConversasUsuario
    {
        public int id { get; set; }

        public int ConversaId { get; set; }

        public int UsuarioId { get; set; }

        public virtual Conversa Conversa { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
