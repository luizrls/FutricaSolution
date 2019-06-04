namespace FutricaApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsuarioDTO
    {
               public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string login { get; set; }

        [Required]
        [StringLength(200)]
        public string nick { get; set; }

        [Required]
        [StringLength(200)]
        public string senha { get; set; }

        public bool flgAtivo { get; set; }

    }
}
