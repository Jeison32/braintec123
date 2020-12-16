using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tcategoria
    {
        public Tcategoria()
        {
            Tinventario = new HashSet<Tinventario>();
        }

        public int Idcategoria { get; set; }
        public string Categoriarepuesto { get; set; }

        public virtual ICollection<Tinventario> Tinventario { get; set; }
    }
}
