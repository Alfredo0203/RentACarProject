using BAL.IServices;
using BAL.Services;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    public class AutosController : Controller
    {
        private IAutosRepository autosRepository;
        private IMarcasRepository marcasRepository;
        private IModelosRepository modelosRepository;
        Contexto contexto = new Contexto();
        public AutosController()
        {
            this.autosRepository = new AutosRepository(new Contexto());
            this.marcasRepository = new MarcasRepository(new Contexto());
            this.modelosRepository = new ModelosRepository(new Contexto());
        }
        // GET: Autos
        public ActionResult MostrarAutos()
        {
            var autos = autosRepository.listarAutos();
            int idCliente = ConvertirAEntero(Session["UserId"].ToString());
            var autosEnCarrito = contexto.Carrito.Where(x => x.FkCliente == idCliente).ToList();
            List<int> IdAutosEnCarrito = new List<int>(); // ---------------------------------- Esta lista almacenará los elementos en Carrito del cliente en sesión
            foreach (var ids in autosEnCarrito) //---------------------------------------------- Se llena el la lista con los Ids productos en Carrito.
            {
                IdAutosEnCarrito.Add(ids.FkAuto);
            }
            Session["AutosEnCarrito"] = IdAutosEnCarrito; // --------------------------------- Asigna los Id de autos a la sesión
            ViewBag.ListaCarrito = Session["AutosEnCarrito"];
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

            ViewBag.ListaMarcas = SeleccionarMarca();
            ViewBag.ListaModelos = SeleccionarModelo();

            return View(auto);
        }
        //AGREGAR AUTOS
        [HttpPost]
        public ActionResult AgregarOEditarAutos(Autos a)
        {
            if (ModelState.IsValid)
            {
              autosRepository.EditarOAgregarAutos(a);
              return RedirectToAction("MostrarAutos");
            }
         
            ViewBag.ListaMarcas = SeleccionarMarca();
            ViewBag.ListaModelos = SeleccionarModelo();
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
           var marcas = new List<SelectListItem>();
           
            foreach (var i in marcasRepository.ObtenerMarcas())
            {
                marcas.Add(new SelectListItem() { Text = i.NombreMarca, Value = i.IdMarca.ToString(), Selected = false });
            }
            return marcas;
        } 
        public List<SelectListItem> SeleccionarModelo()
        {
            List<SelectListItem> modelos = new List<SelectListItem>();

            foreach (var i in modelosRepository.ObtenerModelos())
            {
                modelos.Add(new SelectListItem() { Text = i.NombreModelo, Value = i.IdModelo.ToString(), Selected = false });
            }

            return modelos;
        }

        // GET: DetalleAutos
        public ActionResult DetalleAutos(int IdAuto = 0)
        {
           
                var DetalleAuto = contexto.Autos.Where(x => x.IdAuto == IdAuto).ToList();
                int idCliente = ConvertirAEntero(Session["UserId"].ToString());
                var autosEnCarrito = contexto.Carrito.Where(x => x.FkCliente == idCliente).ToList();
                List<int> IdAutosEnCarrito = new List<int>(); // ---------------------------------- Esta lista almacenará los elementos en Carrito del cliente en sesión
                foreach (var ids in autosEnCarrito) //---------------------------------------------- Se llena el la lista con los Ids productos en Carrito.
                {
                    IdAutosEnCarrito.Add(ids.FkAuto);
                }
                Session["AutosEnCarrito"] = IdAutosEnCarrito; // --------------------------------- Asigna los Id de autos a la sesión
                ViewBag.ListaCarrito = Session["AutosEnCarrito"];
                return View(DetalleAuto);
            
        }

        public static int ConvertirAEntero(string id)
        {
            int clienteInt = int.Parse(id);
            return clienteInt;
        }
    }
}