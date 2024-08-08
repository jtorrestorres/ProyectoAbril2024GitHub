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
            BL.Materia materiaBL = new BL.Materia();
            ML.Result result = materiaBL.GetAllMateria();

            if (result.Correct)
            {
                List<ML.Materia> materias = result.Objects.Cast<ML.Materia>().ToList();
                return View(materias);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener las materias.";
                return View(new List<ML.Materia>());
            }
        }


        public ActionResult Form(int? id)
        {
            ML.Materia materia = new ML.Materia();

            if (id.HasValue)
            {
                BL.Materia materiaBL = new BL.Materia();
                ML.Result result = materiaBL.GetByIdMateria(id.Value);

                if (result.Correct && result.Object != null)
                {
                    materia = (ML.Materia)result.Object;
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al obtener la materia.";
                    return View("Error");
                }
            }

            return View(materia);
        }


        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            BL.Materia materiaBL = new BL.Materia();

            if (materia.IdMateria == 0)
            {
               
                result = materiaBL.AddMateria(materia);
            }
            else
            {
               
                result = materiaBL.UpdateMateria(materia);
            }

            if (result.Correct)
            {
                ViewBag.Message = materia.IdMateria == 0 ? "La materia se agregó exitosamente." : "La materia se actualizó exitosamente.";
                return View("Success");
            }
            else
            {
                ViewBag.Message = materia.IdMateria == 0 ? "Error al agregar la materia." : "Error al actualizar la materia.";
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
                ViewBag.Message = "Se ha eliminado correctamente la materia.";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Error al eliminar la materia.";
                return View("Error");
            }
        }
    }
}