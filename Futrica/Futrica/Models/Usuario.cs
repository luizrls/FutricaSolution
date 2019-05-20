namespace Futrica.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Usuario
    {

        public int id { get; set; }

        public string login { get; set; }

        public string senha { get; set; }

        public string nick { get; set; }

        public bool flgAtivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConversasUsuario> ConversasUsuarios { get; set; }
    }
}
