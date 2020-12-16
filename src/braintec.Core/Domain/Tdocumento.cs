using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tdocumento
    {
        public Tdocumento()
        {
            Tusuario = new HashSet<Tusuario>();
        }

        public int Iddocumento { get; set; }
        public string Tipodocumento { get; set; }

        public virtual ICollection<Tusuario> Tusuario { get; set; }
    }
}
