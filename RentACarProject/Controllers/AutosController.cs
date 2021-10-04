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
        public ActionResult Index()
        {
            return View();
        }
        // GET: DetalleAutos
        public ActionResult DetalleAutos()
        {
            return View();
        }
    }
}