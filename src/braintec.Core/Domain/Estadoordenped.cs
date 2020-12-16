using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Estadoordenped
    {
        public Estadoordenped()
        {
            Ordenpedido = new HashSet<Ordenpedido>();
        }

        public int Idestordenped { get; set; }
        public string Estadoordenped1 { get; set; }

        public virtual ICollection<Ordenpedido> Ordenpedido { get; set; }
    }
}
