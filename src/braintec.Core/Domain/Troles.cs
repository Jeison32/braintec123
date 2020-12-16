using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Troles
    {
        public Troles()
        {
            Menuusuario = new HashSet<Menuusuario>();
            Templeado = new HashSet<Templeado>();
        }

        public int Idroles { get; set; }
        public string Tiporol { get; set; }

        public virtual ICollection<Menuusuario> Menuusuario { get; set; }
        public virtual ICollection<Templeado> Templeado { get; set; }
    }
}
