using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Ordenpagoc
    {
        public int Idordenpag { get; set; }
        public DateTime? Fechaorden { get; set; }
        public int? Numdocumento { get; set; }
        public int? Idopedido { get; set; }
        public int? Idcasoservicio { get; set; }
        public int? Idestordenpag { get; set; }

        public virtual Ordenservicio IdcasoservicioNavigation { get; set; }
        public virtual Estadoordenpag IdestordenpagNavigation { get; set; }
        public virtual Ordenpedido IdopedidoNavigation { get; set; }
        public virtual Tusuario NumdocumentoNavigation { get; set; }
    }
}
