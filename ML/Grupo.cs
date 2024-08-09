using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Turno { get; set; }
        public string Generacion { get; set; }
        public ML.Catalogo Carrera { get; set; }
        public List<object> Grupos { get; set; }
    }
}
