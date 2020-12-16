using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Ordenservicio
    {
        public Ordenservicio()
        {
            Ordenpagoc = new HashSet<Ordenpagoc>();
        }

        public int Idcasoservicio { get; set; }
        public string Resumenservicio { get; set; }
        public int? Numdocumento { get; set; }
        public string Placavehiculo { get; set; }
        public int? Idservicio { get; set; }
        public int? Idestordenserv { get; set; }
        public int? Idprioridad { get; set; }

        public virtual Estadoordenserv IdestordenservNavigation { get; set; }
        public virtual Tprioridad IdprioridadNavigation { get; set; }
        public virtual Tservicio IdservicioNavigation { get; set; }
        public virtual Tusuario NumdocumentoNavigation { get; set; }
        public virtual Tvehiculo PlacavehiculoNavigation { get; set; }
        public virtual ICollection<Ordenpagoc> Ordenpagoc { get; set; }
    }
}
