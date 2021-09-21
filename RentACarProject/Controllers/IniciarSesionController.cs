using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class IniciarSesionController : Controller
    {
        // GET: IniciarSesion
        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }
        public ActionResult Autos ()
        {
            return View();
        }
    }
}