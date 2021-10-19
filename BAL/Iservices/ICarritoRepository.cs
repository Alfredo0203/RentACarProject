using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface ICarritoRepository
    {
        //METODO LISTAR
        List<Carrito> ProductoEnCarrito(int idCliente);
        //MÉTODO GUARDAR
        void AgregarAlCarrito(Carrito carrito);
        //MÉTODO actualizar cantidad de producto en Carrito.
        void ActualizarCantidad(int id, int ClienteId, int cantidad);
        //MÉTODO OBTENER POR ID
        Carrito ObtenerPorId(int id, int ClienteId);
        //MÉTODO Sacar del carrito donde pertenezca al cliente que ha iniciado sesion
        void EliminarDelCarrito(int id, int IdCliente);
    }
}
