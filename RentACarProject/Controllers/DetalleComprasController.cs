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
    [Admin]
    public class DetalleComprasController : Controller
    {

        Contexto contexto = new Contexto();

        // GET: DetalleCompras
        public ActionResult DetalleCompras()
        {
            var compras = contexto.DetalleCompras.Include(x => x.Compras).ToList();
            var proveedores = contexto.Compras.Include(x => x.Proveedores).ToList();

            var lista = contexto.DetalleCompras.ToList();
            return View(lista);
        }

    }
}