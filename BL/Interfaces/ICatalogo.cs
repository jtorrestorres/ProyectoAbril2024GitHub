﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICatalogo
    {
        ML.Result GetAll();
        ML.Result Delete(ML.Carrera carrera);
        ML.Result GetById(int idCarrera);
        ML.Result Add(ML.Carrera carrera);
        ML.Result Update(ML.Carrera carrera);
    }
}
