using BAL.IServices;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class AutosController : Controller
    {
        private IAutosRepository autosRepository;
        private Contexto contexto;

        public AutosController()
        {
            this.autosRepository = new AutosRepository(new Contexto());
        }
        // GET: Autos
        public ActionResult MostrarAutos()
        {
            ViewBag.listaMarcas = SeleccionarMarca();
            ViewBag.listaModelos = SeleccionarModelo();
            var autos = autosRepository.listarAutos();
            return View(autos);
        }

        // GET: EDITAR AUTOS
        public ActionResult AgregarOEditarAutos(int id = 0)
        {
            var auto = new Autos();
            if (id > 0)
            {
                auto = autosRepository.ObtenerPorId(id);
            }
            return View(auto);
        }
        //AGREGAR AUTOS
        [HttpPost]
        public ActionResult AgregarOEditarAutos(Autos a)
        {
            if (ModelState.IsValid)
            {
              autosRepository.EditarOAgregarAutos(a);
            }
            return View(a);
        }
        //ELIMINAR AUTO
        public ActionResult EliminarAuto(int id)
        {
            if (id>0)
            {
                autosRepository.EliminarAuto(id);
            }
            return RedirectToAction("MostrarAutos");
        }

        public List<SelectListItem> SeleccionarMarca()
        {
            var listaMarcas = new List<SelectListItem>();
            var marcas = contexto.Marcas.ToList();
            foreach (var i in  marcas)
            {
                listaMarcas.Add(new SelectListItem { Text = i.NombreMarca, Value = i.IdMarca.ToString() });
            }
            return listaMarcas;
        } 
        public List<SelectListItem> SeleccionarModelo()
        {
            var listaModelos = new List<SelectListItem>();
            var marcas = contexto.Modelos.ToList();
            foreach (var i in  marcas)
            {
                listaModelos.Add(new SelectListItem { Text = i.NombreModelo, Value = i.IdModelo.ToString() });
            }
            return listaModelos;
        }

        // GET: DetalleAutos
        public ActionResult DetalleAutos()
        {
            return View();
        }
    }
}