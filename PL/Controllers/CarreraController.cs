using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CarreraController : Controller
    {
        // GET: Carrera
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }
    }
}