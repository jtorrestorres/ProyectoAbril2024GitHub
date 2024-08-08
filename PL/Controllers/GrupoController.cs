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
                ViewBag.Mensaje = "Se ha eliminado el registro.";
            }

            return PartialView("Modal");
        }
    }
}