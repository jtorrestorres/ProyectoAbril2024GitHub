using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Catalogo
    {
        public int IdCatalogo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public List<object> Catalogos { get; set; }
    }
}
