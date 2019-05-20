namespace Futrica.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class MensagemTipos
    {

        public int id { get; set; }

        public string nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensagen> Mensagens { get; set; }
    }
}
