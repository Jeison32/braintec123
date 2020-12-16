using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Estadousuarioemp
    {
        public Estadousuarioemp()
        {
            Templeado = new HashSet<Templeado>();
        }

        public int Idestadou { get; set; }
        public string Estadousuario { get; set; }

        public virtual ICollection<Templeado> Templeado { get; set; }
    }
}
