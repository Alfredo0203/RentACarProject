using DAL.Models;
using RentACarProject.Security;
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
            pass = Encriptado.EncryptPassword(pass);
            var Admin = contexto.Administradores.FirstOrDefault(x => x.Correo.Equals(correo) && x.Contra.Equals(pass));
            var Cliente = contexto.Clientes.FirstOrDefault(x => x.Correo.Equals(correo) && x.Contra.Equals(pass));

            if (Admin != null)
            {

                Session["UserId"] = Admin.IdAdministrador.ToString();
                Session["NombreAdmin"] = Admin.Nombre + " " + Admin.Apellido;
                Session["UserRol"] = Admin.Rol.ToString();
                return RedirectToAction("MostrarProveedores", "Proveedores");
            }
            else if (Cliente != null)
            {
                    Session["UserId"] = Cliente.IdCliente.ToString();
                    Session["NombreUsuario"] = Cliente.NombreCliente;
                    Session["UserRol"] = Cliente.Rol.ToString();
                    return RedirectToAction("MostrarAutos", "Autos");
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