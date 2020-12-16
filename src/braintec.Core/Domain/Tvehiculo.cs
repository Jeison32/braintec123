using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tvehiculo
    {
        public Tvehiculo()
        {
            Ordenservicio = new HashSet<Ordenservicio>();
        }

        public string Placavehiculo { get; set; }
        public string Marcavehiculo { get; set; }
        public string Modelovehiculo { get; set; }
        public int? Cilindrajevehiculo { get; set; }
        public int? Kilometrajevehiculo { get; set; }
        public string Trasmisionvehiculo { get; set; }
        public int? Aniovehiculo { get; set; }
        public int Numdocumento { get; set; }

        public virtual Tusuario NumdocumentoNavigation { get; set; }
        public virtual ICollection<Ordenservicio> Ordenservicio { get; set; }
    }
}
