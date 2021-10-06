
using BAL.Iservices;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class ClientesController : Controller
    {
        Contexto contexto = new Contexto();

        private IClientesRepository clientesRepository;

        public ClientesController()
        {
            this.clientesRepository = new ClientesRepository(new Contexto());
        }
        // GET: Clientes
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult MostrarClientes()
        {
            var model = contexto.Clientes.ToList();

            return View(model);
        }
        public ActionResult Registrarse(int IdClien = 0)
        {
            var model = new Clientes();

            if (IdClien > 0)
            {
                model = clientesRepository.ObtenerId(IdClien);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Registrarse(Clientes model)
        {

            if (ModelState.IsValid)
            {
                model.Rol = Roles.cliente;
                model.Estado = "Activo";
                var hecho = clientesRepository.AgregarEditar(model);
                if (hecho)
                {
                    return RedirectToAction("MostrarClientes");
                }
            }
            return View(model);
        }

        public ActionResult EliminarCliente(int IdClien)
        {
            var hecho = clientesRepository.EliminarCliente(IdClien);

            return RedirectToAction("MostrarClientes");
        }
    }
}
