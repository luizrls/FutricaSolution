namespace FutricaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Conversa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conversa()
        {
            ConversasUsuarios = new HashSet<ConversasUsuario>();
            Mensagens = new HashSet<Mensagen>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        public int UsuarioId { get; set; }

        public bool flgAtivo { get; set; }

        public bool flgGrupo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConversasUsuario> ConversasUsuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensagen> Mensagens { get; set; }
    }
}
