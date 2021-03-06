using BAL.IServices;
using BAL.Services;
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
    [Cliente]
    public class CarritoController : Controller
    {
        private readonly ICarritoRepository carritoRepository;
        private Contexto contexto = new Contexto();

        public CarritoController()
        {
            this.carritoRepository = new CarritoRepository(new Contexto());
        }
        // GET: Carrito
        public ActionResult Carrito()
        {
            //Manda la lista de inventario a la vista y  también la lista de producto de cliente por medio ViewBag(Para comparar y mostrar)
            try
            {
                int idCliente = ConvertirAEntero(Session["UserId"].ToString()); //Convierte el id del cliente en sesión a entero
                var autosEnCarrito = contexto.Carrito.Where(x => x.FkCliente == idCliente).ToList(); // Almacena listado de productos en carrito de acuerdo alcliente
                var inventario = contexto.Autos.ToList();
                ViewBag.ListaCarrito = autosEnCarrito;
                return View(inventario);
            }
            catch (Exception)
            {
                return View();
            }

        }

        // Agregar Al Carrito

        public JsonResult SeleccionarProducto(int id = 0)
        {
            bool success = false;
            if (id > 0)
            {
                int clienteInt = ConvertirAEntero(Session["UserId"].ToString());
                bool ExisteEnCarrito = contexto.Carrito.Any(x=> x.FkCliente == clienteInt);
                if (ExisteEnCarrito) return Json(success, JsonRequestBehavior.AllowGet);
                try
                {  //Crea un objeto de la entidad carrito
                    Carrito elemento = new Carrito();
                    //Obtiene y convierte el id Del Cliente en sesión
                    //Asignación de valores al objeto
                    elemento.FkAuto = id;
                    elemento.CantidadDias = 1;
                    elemento.FkCliente = contexto.Clientes.FirstOrDefault(x => x.IdCliente == clienteInt).IdCliente;
                    // Llama la función para agregar y le envía el objeto comoparámetro
                    carritoRepository.AgregarAlCarrito(elemento);
                    success = true;
                }
                catch (Exception) { }
            }
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //QUITAR ELEMENTOS DELCARRITO
        public JsonResult EliminarElementoDeLaLista(int id = 0)
        {
            bool success = false;
            if (id > 0)
            {
                try
                {
                    // Obtiene el Id del cliente y lo convierte a entero
                    int clienteInt = ConvertirAEntero(Session["UserId"].ToString());
                    // LLama el método para eliminary le pasa el id de auto y id del cliente para eliminar solo los que le pertenecen a este
                    carritoRepository.EliminarDelCarrito(id, clienteInt);
                    success = true;
                }
                catch (Exception) { }
            }
            return Json(success, JsonRequestBehavior.AllowGet);
        }
        // Método realizar la compra del cliente
        public JsonResult RealizarPrestamo()
        {
            bool PrestamoFinalizado = false;
            const string StringEstado = "Ocupado";
            string rolClienteString = Session["UserRol"].ToString(); // ------------------------------------------------------------------------------------------ Almacena nombre del rol en una variable
            int clienteInt = ConvertirAEntero(Session["UserId"].ToString()); // ------------------------------------------------------------- Convirte a entero y almacena id delcliente
            var miProducto = contexto.Carrito.FirstOrDefault(x => x.FkCliente == clienteInt); // -------------------------------------------------------- Obtiene listado de producto en carrito del cliente logeado
            var IdCliente = contexto.Clientes.FirstOrDefault(x => x.IdCliente == clienteInt && rolClienteString.Equals("cliente")).IdCliente; // -------------- Obtiene el id delcliente logeado
            var AutoEnInventario = contexto.Autos.FirstOrDefault(x => x.IdAuto == miProducto.FkAuto); // -------------------------------------------- De la tabla inventario Obtiene los datos del producto que tenía el cliente en carrito
            //const string SinDevolver = "si";
            var SinDevolver = contexto.HistorialAlquiler.FirstOrDefault(x => x.FkCliente == clienteInt && x.Autos.Estado.Trim() == StringEstado.Trim());
           
            bool Ocupado = false;
            if (SinDevolver != null)
            {
                return Json("si", JsonRequestBehavior.AllowGet);
            }
               else if (AutoEnInventario.Estado.Trim() == StringEstado.Trim())
            {
                Ocupado = true;
            }
            //INICIO DE PROCESO PARA GUARDAR LOS PRODUCTOS DEL PEDIDO DELCLIENTE
            if (Ocupado == true)
            {
                return Json(PrestamoFinalizado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // CAPTURAMOS LAS ESPECIFICACIONES DEL AUTO EN PROCESO DE COMPRA DE LA TABLA INVENTARIO
                var Precio = contexto.Autos.FirstOrDefault(x => x.IdAuto == miProducto.FkAuto).PrecioDia;
                var Marca = contexto.Autos.FirstOrDefault(x => x.IdAuto == miProducto.FkAuto).Marcas.NombreMarca;
                var Modelo = contexto.Autos.FirstOrDefault(x => x.IdAuto == miProducto.FkAuto).Modelos.NombreModelo;
                var nuevoPrestamo = new HistorialAlquiler(); 
                nuevoPrestamo.FkCliente = IdCliente;  
                nuevoPrestamo.FkAuto = miProducto.FkAuto;
                nuevoPrestamo.CantidadDias = miProducto.CantidadDias;
                nuevoPrestamo.PrecioTotal = Precio * miProducto.CantidadDias;
                nuevoPrestamo.FechaInicio = DateTime.Now;
                //Se saca el producto del carrito por medio del id del cliente y el id de auto
                carritoRepository.EliminarDelCarrito(miProducto.FkAuto, clienteInt);
                //Se llama la función para guardar los datos del objeto de detalleventas
                contexto.Entry(nuevoPrestamo).State = EntityState.Added;
                AutoEnInventario.Estado = StringEstado.Trim();
                contexto.Entry(AutoEnInventario).State = EntityState.Modified;
                //Se guardan los cambios en la base de datos
                contexto.SaveChanges();

                PrestamoFinalizado = true;

                return Json(PrestamoFinalizado, JsonRequestBehavior.AllowGet);
            }
        }
        // Recibe el id del auto y la cantidad 
        public JsonResult EditarCantidad(int id, int cantidad)
        {
            bool success = false;
            try
            {
                // Obtiene el id del cliente logeado y lo convierte a entero
                int clienteId = ConvertirAEntero(Session["UserId"].ToString());
                // LLama elmétodo actualizar y le envía elid del auto, el nombre del cliente (para encontrar el correcto porque pueden haber varios con el mismo id)
                carritoRepository.ActualizarCantidad(id, clienteId, cantidad);
                success = true;
            }
            catch (Exception) { }

            return Json(success, JsonRequestBehavior.AllowGet);
        }




        public static int ConvertirAEntero(string id)
        {
            int clienteInt = int.Parse(id);
            return clienteInt;
        }


    }
}