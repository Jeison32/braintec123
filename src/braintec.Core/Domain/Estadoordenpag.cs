using System;
using System.Collections.Generic;

namespace braintec.Infrastructure.Data
{
    public partial class Estadoordenpag
    {
        public Estadoordenpag()
        {
            Ordenpagoc = new HashSet<Ordenpagoc>();
        }

        public int Idestordenpag { get; set; }
        public string Estadoordenpag1 { get; set; }

        public virtual ICollection<Ordenpagoc> Ordenpagoc { get; set; }
    }
}
