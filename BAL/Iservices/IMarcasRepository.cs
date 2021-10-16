using System;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IMarcasRepository : IDisposable
    {

        IEnumerable<Marcas> ObtenerMarcas();

        bool AgregarOEditMarca(Marcas model);

        Marcas ObtenerMarcaPorId(int IdMarca);

        bool EliminarMarca(int IdMarca);

    }
}
