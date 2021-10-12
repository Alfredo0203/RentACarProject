using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IProveedoresRepository : IDisposable
    {

        bool CreateOrEdit(Proveedores model);
        Proveedores ObtenerId(int idProveedor);
        bool Delete(int idProveedor);

    }
}
