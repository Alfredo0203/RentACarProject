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

        public JsonResult Devolver(int id= 0)
        {
            bool success = false;
            if(id >0)
            {
                var model = contexto.Autos.FirstOrDefault(x => x.IdAuto == id);
                const string StringEstado = "Ocupado";
                const string StringEstado2 = "Disponible";
                if (model.Estado.Trim() == StringEstado.Trim())
                {
                    model.Estado = StringEstado2.Trim();
                    contexto.Entry(model).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                    return Json(success, JsonRequestBehavior.AllowGet);
                }
            } 
            
                return Json(success, JsonRequestBehavior.AllowGet);
           
        }

        public static int ConvertirAEntero(string id)
        {
            int clienteInt = int.Parse(id);
            return clienteInt;
        }

    }

}