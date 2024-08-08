using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class GrupoController : Controller
    {
        BL.Grupo grupoBL = new BL.Grupo();
        BL.Carrera carreraBL = new BL.Carrera();
        // GET: Grupo
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = grupoBL.GetAll();
            ML.Grupo grupo = new ML.Grupo();

            grupo.Grupos = result.Objects;

            return View(grupo);
        }

        [HttpGet]
        public ActionResult Form(int idGrupo)
        {
            ML.Grupo grupo=new ML.Grupo();
            grupo.Carrera =new ML.Carrera();

            if (idGrupo > 0)
            {
                ML.Result result = grupoBL.GetById(idGrupo);
                if (result.Correct)
                {
                    ML.Result resultCarrera = carreraBL.GetAll();
                }
                else
                {

                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int idGrupo)
        {
            ML.Grupo grupo = new ML.Grupo();
            grupo.IdGrupo = idGrupo;
            ML.Result result = grupoBL.Delete(grupo);

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