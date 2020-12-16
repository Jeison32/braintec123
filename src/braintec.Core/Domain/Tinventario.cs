using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tinventario
    {
        public Tinventario()
        {
            Ordenpedido = new HashSet<Ordenpedido>();
        }

        public int Refrepuesto { get; set; }
        public string Nombrerepuesto { get; set; }
        public string Marcarepuesto { get; set; }
        public int? Cantidadexistente { get; set; }
        public decimal? Tarifarepuesto { get; set; }
        public int? Idcategoria { get; set; }
        public int? Idproveedor { get; set; }

        public virtual Tcategoria IdcategoriaNavigation { get; set; }
        public virtual Tproveedor IdproveedorNavigation { get; set; }
        public virtual ICollection<Ordenpedido> Ordenpedido { get; set; }
    }
}
