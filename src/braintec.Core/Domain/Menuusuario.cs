using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Menuusuario
    {
        public Menuusuario()
        {
            InverseCodigosubmenuNavigation = new HashSet<Menuusuario>();
        }

        public byte Mcodigo { get; set; }
        public string Mnombre { get; set; }
        public string Url { get; set; }
        public string Tipomenu { get; set; }
        public int? Idroles { get; set; }
        public byte? Codigosubmenu { get; set; }

        public virtual Menuusuario CodigosubmenuNavigation { get; set; }
        public virtual Troles IdrolesNavigation { get; set; }
        public virtual ICollection<Menuusuario> InverseCodigosubmenuNavigation { get; set; }
    }
}
