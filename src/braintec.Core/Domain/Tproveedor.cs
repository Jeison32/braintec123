using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tproveedor
    {
        public Tproveedor()
        {
            Tinventario = new HashSet<Tinventario>();
        }

        public int Idproveedor { get; set; }
        public string Rsocialproveedor { get; set; }
        public string Percontactoproveedor { get; set; }
        public long? Telefonoproveedor { get; set; }
        public string Correoproveedor { get; set; }

        public virtual ICollection<Tinventario> Tinventario { get; set; }
    }
}
