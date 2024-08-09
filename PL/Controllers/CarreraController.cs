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
        public ActionResult Form(int idCarrera)
        {
            ML.Carrera carrera = new ML.Carrera();
            if (idCarrera>0)
            {
                ML.Result result=carreraBL.GetById(idCarrera);

                if (result.Correct)
                {
                    carrera = (ML.Carrera) result.Object;

                }
                else
                {
                    ViewBag.Mensaje = "No se ha encontrado el registro" + result.ErrorMessage;
                    return PartialView("Model");
                }

            }
            else
            {
                return View(carrera);
            }

            return View(carrera);
        }

        [HttpGet]
        public ActionResult Delete(int idCarrera)
        {
            ML.Carrera carrera = new ML.Carrera();
            carrera.IdCarrera = idCarrera;

            ML.Result result = carreraBL.Delete(carrera);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado el registro.";
            }
            else
            {
                ViewBag.Mensaje = "No se ha eliminado el registro" + result.ErrorMessage;
            }

            return PartialView("Modal");
        }
    }
}