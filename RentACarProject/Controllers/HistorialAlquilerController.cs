using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class HistorialAlquilerController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: HistorialAlquiler
        public ActionResult HistorialAlquiler()
        {
            //var compras = contexto.DetalleCompras.Include(x => x.Compras).ToList();

            var clientes = contexto.HistorialAlquiler.Include(x => x.Clientes).ToList();
            var auto = contexto.HistorialAlquiler.Include(x => x.Autos).ToList();

            var model = contexto.HistorialAlquiler.ToList();
            return View(model);
        }
    }
}