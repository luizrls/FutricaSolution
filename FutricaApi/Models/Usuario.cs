namespace FutricaApi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            ConversasUsuarios = new HashSet<ConversasUsuario>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string login { get; set; }

        [Required]
        [StringLength(200)]
        public string senha { get; set; }

        [Required]
        [StringLength(200)]
        public string nick { get; set; }

        public bool flgAtivo { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConversasUsuario> ConversasUsuarios { get; set; }
    }
}
