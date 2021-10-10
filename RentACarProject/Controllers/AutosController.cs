using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class AutosController : Controller
    {
        // GET: Autos
        public ActionResult MostrarAutos()
        {
            return View();
        }
        // GET: DetalleAutos
        public ActionResult DetalleAutos()
        {
            return View();
        }

        public ActionResult AgregarOEditarAutos()
        {
            return View();
        }
    }
}