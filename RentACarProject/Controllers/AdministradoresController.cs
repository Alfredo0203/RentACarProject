using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class AdministradoresController : Controller
    {
        // GET: Administradores
        public ActionResult MostrarAdministradores()
        {
            return View();
        }
    }
}