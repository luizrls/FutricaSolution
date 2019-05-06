namespace FutricaApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MensagemTiposDTO
    {

        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string nome { get; set; }

    }
}
