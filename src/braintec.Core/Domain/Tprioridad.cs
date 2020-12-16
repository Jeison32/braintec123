using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tprioridad
    {
        public Tprioridad()
        {
            Ordenservicio = new HashSet<Ordenservicio>();
        }

        public int Idprioridad { get; set; }
        public string Tipoprioridad { get; set; }

        public virtual ICollection<Ordenservicio> Ordenservicio { get; set; }
    }
}
