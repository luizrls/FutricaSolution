namespace FutricaApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConversaDTO
    {
 
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        public int UsuarioId { get; set; }

        public bool flgAtivo { get; set; }

        public bool flgGrupo { get; set; }

    }
}
