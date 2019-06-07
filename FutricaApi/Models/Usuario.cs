namespace FutricaApi.Models
{
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
            UsuariosContatos = new HashSet<UsuariosContato>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string senha { get; set; }

        [Required]
        [StringLength(200)]
        public string nick { get; set; }

        public bool flgAtivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConversasUsuario> ConversasUsuarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuariosContato> UsuariosContatos { get; set; }
    }
}
