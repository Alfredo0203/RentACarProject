using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Iservices
{
    public interface IClientesRepository : IDisposable
    {
        bool AgregarEditar(Clientes model);
        Clientes ObtenerId(int IdClien);
        bool EliminarCliente(int IdClien);

    }
}
