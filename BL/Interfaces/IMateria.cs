using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IMateria
    {
        ML.Result GetAllMateria();
        ML.Result AddMateria(ML.Materia materia);
        ML.Result UpdateMateria(ML.Materia materia);
        ML.Result DeleteMateria(int id);
    }
}
