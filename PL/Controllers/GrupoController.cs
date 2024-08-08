using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class GrupoController : Controller
    {
        // GET: Grupo
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Grupo.GetAll();
            ML.Grupo grupo = new ML.Grupo();

            grupo.Grupos = result.Objects;

            return View(grupo);
        }
    }
}