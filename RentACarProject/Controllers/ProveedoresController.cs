using BAL.IServices;
using BAL.Services;
using DAL.Models;
using RentACarProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    [Permisos]
    [Admin]
    public class ProveedoresController : Controller
    {

        Contexto contexto = new Contexto();


        private IProveedoresRepository proveedoresRepository;


        public ProveedoresController ()
        {
            this.proveedoresRepository = new ProveedoresRepository(new Contexto());
        }


        // GET: Proveedores
        public ActionResult MostrarProveedores()
        {
            var model = contexto.Proveedores.ToList();

            return View(model);
        }


        public ActionResult AgregarOEditar(int idProveedor = 0)
        {
            var model = new Proveedores();

            if (idProveedor > 0)
            {
                model = proveedoresRepository.ObtenerId(idProveedor);
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult AgregarOEditar(Proveedores model)
        {
            if (ModelState.IsValid)
            {
                var accion = proveedoresRepository.CreateOrEdit(model);
                if (accion)
                {
                    return RedirectToAction("MostrarProveedores");
                }
            }
            return View(model);
        }


        public ActionResult Eliminar (int idProveedor)
        {
            var accion = proveedoresRepository.Delete(idProveedor);

            return RedirectToAction("MostrarProveedores");
        }


    }
}