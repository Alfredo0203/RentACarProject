using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RentACarProject.Controllers
{
    public class IniciarSesionController : Controller
    {

        Contexto contexto = new Contexto();

        // GET: IniciarSesion
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarSesion(string correo, string pass)
        {

                var Info = contexto.Administradores.FirstOrDefault(x => x.Correo.Equals(correo) && x.Contra.Equals(pass));

                if (Info != null)
                {
                    Session["IdAdministrador"] = Info.IdAdministrador.ToString();
                    return RedirectToAction("MostrarProveedores", "Proveedores");
                }
                else
                {
                    ModelState.AddModelError("InvalidCredentials", "El correo o contraseña son incorrectos");
                }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("IniciarSesion");
        }

        public ActionResult Registrarse()
        {
            return View();
        }
    }
}