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
            BL.Grupo grupoBL = new BL.Grupo();
            ML.Result result = grupoBL.GetAll();
            ML.Grupo grupo = new ML.Grupo();

            grupo.Grupos = result.Objects;

            return View(grupo);
        }
    }
}