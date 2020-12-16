using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Ordenpedido
    {
        public Ordenpedido()
        {
            Ordenpagoc = new HashSet<Ordenpagoc>();
        }

        public int Idopedido { get; set; }
        public DateTime? Fpedido { get; set; }
        public int? Numdocumento { get; set; }
        public int? Refrepuesto { get; set; }
        public int? Idestordenped { get; set; }

        public virtual Estadoordenped IdestordenpedNavigation { get; set; }
        public virtual Tusuario NumdocumentoNavigation { get; set; }
        public virtual Tinventario RefrepuestoNavigation { get; set; }
        public virtual ICollection<Ordenpagoc> Ordenpagoc { get; set; }
    }
}
