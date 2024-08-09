using ML;
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
            ML.Result resultCarrera = carreraBL.GetAll();

            if (idGrupo > 0)
            {
                ML.Result result = grupoBL.GetById(idGrupo);
                if (result.Correct)
                {
                    grupo = (ML.Grupo)result.Object;
                    grupo.Carrera.Carreras = resultCarrera.Objects;

                }
                else
                {
                    ViewBag.Mensaje = "No se ha encontrado el registro" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                grupo.Carrera.Carreras = resultCarrera.Objects;
            }

            return View(grupo);
        }

        [HttpPost]
        public ActionResult Form(ML.Grupo grupo)
        {
            ML.Result result = new ML.Result();
            if (grupo.IdGrupo>0)
            {
                result = grupoBL.Update(grupo);
            }
            else
            {
                result = grupoBL.Add(grupo);
            }

            if (result.Correct)
            {
                ViewBag.Mensaje = "Se agrego correctamente.";
            }
            else
            {
                ViewBag.Mensaje = "No se agrego correctamente " + result.ErrorMessage;
            }
            return PartialView("Modal");
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