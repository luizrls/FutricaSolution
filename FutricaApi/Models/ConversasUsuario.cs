namespace FutricaApi.Models
{
    using Newtonsoft.Json;
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
        [JsonIgnore]
        public virtual Conversa Conversa { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
