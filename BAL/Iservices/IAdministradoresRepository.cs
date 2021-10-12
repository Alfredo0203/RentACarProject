using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IAdministradoresRepository: IDisposable
    {
        bool AgregarEditar(Administradores model);
        Administradores ObtenerId(int IdAdmin);
        bool EliminarAdmin(int IdAdmin);

    }
}
