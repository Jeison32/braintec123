using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Tusuario
    {
        public Tusuario()
        {
            Ordenpagoc = new HashSet<Ordenpagoc>();
            Ordenpedido = new HashSet<Ordenpedido>();
            Ordenservicio = new HashSet<Ordenservicio>();
            Templeado = new HashSet<Templeado>();
            Tvehiculo = new HashSet<Tvehiculo>();
        }

        public int Numdocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long? Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int? Iddocumento { get; set; }

        public virtual Tdocumento IddocumentoNavigation { get; set; }
        public virtual ICollection<Ordenpagoc> Ordenpagoc { get; set; }
        public virtual ICollection<Ordenpedido> Ordenpedido { get; set; }
        public virtual ICollection<Ordenservicio> Ordenservicio { get; set; }
        public virtual ICollection<Templeado> Templeado { get; set; }
        public virtual ICollection<Tvehiculo> Tvehiculo { get; set; }
    }
}
