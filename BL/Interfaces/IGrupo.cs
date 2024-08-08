using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IGrupo
    {
        ML.Result GetAll();
        ML.Result Delete(ML.Grupo grupo);
        ML.Result GetById(int idGrupo);
    }
}
