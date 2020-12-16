using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Estadoordenserv
    {
        public Estadoordenserv()
        {
            Ordenservicio = new HashSet<Ordenservicio>();
        }

        public int Idestordenserv { get; set; }
        public string Estadoordenserv1 { get; set; }

        public virtual ICollection<Ordenservicio> Ordenservicio { get; set; }
    }
}
