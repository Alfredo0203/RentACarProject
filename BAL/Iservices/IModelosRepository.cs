using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IModelosRepository : IDisposable
    {

        IEnumerable<Modelos> ObtenerModelos();
        
        bool AgregarOEditModelo(Modelos modelo);

        Modelos ObtenerModeloPorId(int IdModelo);

        bool EliminarModelo(int IdModelo);

    }
}
