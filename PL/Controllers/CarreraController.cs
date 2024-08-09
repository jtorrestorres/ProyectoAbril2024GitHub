using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CarreraController : Controller
    {
        BL.Carrera carreraBL = new BL.Carrera();
        // GET: Carrera
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Carrera carrera = new ML.Carrera();
            ML.Result result = carreraBL.GetAll();
            carrera.Carreras = result.Objects;
            return View(carrera);
        }

        [HttpGet]
        public ActionResult Delete(ML.Carrera carrera)
        {

            return View();
        }
    }
}