using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices 
{
    public interface IAutosRepository : IDisposable
    {
        //LISTAR AUTOS
        List<Autos> listarAutos();
        //OBTENER AUTO POR ID
        Autos ObtenerPorId(int id);
        //EDITAR O AGREGAR AUTOS
        void EditarOAgregarAutos(Autos autos);
        //ELIMINAR AUTOS
        void EliminarAuto(int id);
    }
}
