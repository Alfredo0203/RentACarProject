using DAL.Models;
using RentACarProject.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    [Permisos]
    public class HistorialAlquilerController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: HistorialAlquiler
        public ActionResult HistorialAlquiler()
        {
            //var compras = contexto.DetalleCompras.Include(x => x.Compras).ToList();
            int idCliente = ConvertirAEntero(Session["UserId"].ToString()); //Convierte el id del cliente en sesión a entero

            var clientes = contexto.HistorialAlquiler.Include(x => x.Clientes).ToList();
            var auto = contexto.HistorialAlquiler.Include(x => x.Autos).ToList();
            if (Session["UserRol"].Equals("admin"))
            {
                var model = contexto.HistorialAlquiler.ToList();
                return View(model);
            }
            else
            {
                var model = contexto.HistorialAlquiler.Where(x => x.FkCliente == idCliente).ToList();
                return View(model);
            }
        }

        public static int ConvertirAEntero(string id)
        {
            int clienteInt = int.Parse(id);
            return clienteInt;
        }

    }

}