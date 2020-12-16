using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tservicio
    {
        public Tservicio()
        {
            Ordenservicio = new HashSet<Ordenservicio>();
        }

        public int Idservicio { get; set; }
        public string Nombreservicio { get; set; }
        public string Descservicio { get; set; }
        public decimal? Tarifaservicio { get; set; }

        public virtual ICollection<Ordenservicio> Ordenservicio { get; set; }
    }
}
