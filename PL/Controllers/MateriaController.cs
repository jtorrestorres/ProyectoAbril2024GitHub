using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllMateria()
        {
            ML.Result result = new ML.Result();
            BL.Materia materia = new BL.Materia();
            result = materia.GetAllMateria();

            if (result.Correct)
            {
                return View(result.Objects);
            }
            else
            {
                ViewBag.Message = "Ha ocurrido un error al mostrar las materias";
                return View("Error");
            }
        }

        public ActionResult AddMateria(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            BL.Materia materiaBL = new BL.Materia();
            result = materiaBL.AddMateria(materia);

            if (result.Correct)
            {
                ViewBag.Message = "La materia se agrego exitosamente";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Error al agregar la materia";
                return View("Error");
            }
        }

        public ActionResult UpdateMateria(int id, ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            BL.Materia materiaBL = new BL.Materia();
            materia.IdMateria = id;
            result = materiaBL.UpdateMateria(materia);

            if (result.Correct)
            {
                ViewBag.Message = "La materia se actualizo exitosamente";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Error al actualizar la materia";
                return View("Error");
            }
        }

        public ActionResult DeleteMateria(int id)
        {
            ML.Result result = new ML.Result();
            BL.Materia materiaBL = new BL.Materia();
            result = materiaBL.DeleteMateria(id)
;

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente la materia";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Error al eliminar la materia";
                return View("Error");
            }
        }
    }
}