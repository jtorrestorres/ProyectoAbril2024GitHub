using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICatalogo
    {
        ML.Result GetAll();
        ML.Result Delete(ML.Catalogo catalogo);
        ML.Result GetById(int idCatalogo);
        ML.Result Add(ML.Catalogo catalogo);
        ML.Result Update(ML.Catalogo catalogo);
    }
}
