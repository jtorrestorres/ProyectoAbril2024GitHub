using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICarrera
    {
        ML.Result GetAll();
        ML.Result Delete(ML.Carrera carrera);
    }
}
