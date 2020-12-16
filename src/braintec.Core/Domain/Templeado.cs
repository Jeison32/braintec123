using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Templeado
    {
        public int Idempleado { get; set; }
        public string Cargoempleado { get; set; }
        public string Usuarioempleado { get; set; }
        public string Contrasenaempleado { get; set; }
        public DateTime? Fcreacion { get; set; }
        public DateTime? Fultimoacceso { get; set; }
        public int? Numdocumento { get; set; }
        public int? Idroles { get; set; }
        public int? Idestadou { get; set; }

        public virtual Estadousuarioemp IdestadouNavigation { get; set; }
        public virtual Troles IdrolesNavigation { get; set; }
        public virtual Tusuario NumdocumentoNavigation { get; set; }
    }
}
