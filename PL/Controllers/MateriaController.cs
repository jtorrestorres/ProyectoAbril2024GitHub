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
                ViewBag.Message = "La materia se ha guardado exitosamente.";
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al guardar la materia.";
            }

            return View(materia); 
        }


        public ActionResult DeleteMateria(int id)
        {
            ML.Result result = new ML.Result();

           
            result = new BL.Materia().DeleteMateria(id)
        ;

            if (result.Correct)
            {
                ViewBag.Message = "La materia fue eliminada correctamente.";
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al intentar eliminar la materia: " + result.ErrorMessage;
            }

            return View("Index", new BL.Materia().GetAllMateria().Objects.Cast<ML.Materia>().ToList());
        }
    }
}