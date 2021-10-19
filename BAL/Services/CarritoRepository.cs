using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class CarritoRepository : ICarritoRepository, IDisposable
    {
        private readonly Contexto contexto;


        public CarritoRepository(Contexto contexto1)
        {
            this.contexto = contexto1;
        }

        //Recibe el id del Auto, el id de cliente que ha inicido sesión y la cantidad
        public void ActualizarCantidad(int id, int ClienteId, int cantidad)
        {
            //Obtiene los datos del auto por medio su Id y el IdCliente, Edita la cantidad y guarda los cambios
            var carrito = ObtenerPorId(id, ClienteId);
            carrito.CantidadDias = cantidad;
            contexto.Entry(carrito).State = EntityState.Modified;
            contexto.SaveChanges();

        }
        // Método Agregar Al Carrito, Recibe objeto de la tabla Carrito como parametro
        public void AgregarAlCarrito(Carrito carrito)
        {
            //
            contexto.Entry(carrito).State = EntityState.Added;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        // Recibe el Id del auto y el id del cliente como parámetro
        public Carrito ObtenerPorId(int id, int ClienteId)
        {
            //Obtiene los datos del auto por medio su Id y el IdCliente
            var auto = contexto.Carrito.FirstOrDefault(x => x.FkAuto == id && x.FkCliente == ClienteId);
            return auto;
        }
        // Recibe el idCliente que ha iniciado sesión
        public List<Carrito> ProductoEnCarrito(int idCliente)
        {
            //Obtiene la lista de autos en Carrito que pertenecen al Id del cliente
            var ProductoEnCarrito = contexto.Carrito.Where(x => x.FkCliente== idCliente).ToList();
            return ProductoEnCarrito;
        }
        // Recibe el Id del Auto y el Id de cliente en sesión
        public void EliminarDelCarrito(int id, int IdCliente)
        {
            //Obtiene los datos del auto según el cliente y el id del auto
            var model = contexto.Carrito.FirstOrDefault(x => x.FkCliente == IdCliente && x.FkAuto == id);

            if (model != null)
            {
                contexto.Entry(model).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}
