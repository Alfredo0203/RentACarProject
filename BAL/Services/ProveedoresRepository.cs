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
    public class ProveedoresRepository : IProveedoresRepository, IDisposable
    {

        private readonly Contexto contexto;

        public ProveedoresRepository(Contexto contexto_)
        {
            this.contexto = contexto_;
        }

        public bool CreateOrEdit(Proveedores model)
        {
            bool accion;

            try
            {
                if (model.IdProveedor > 0)
                {
                    contexto.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(model).State = EntityState.Added;
                }

                contexto.SaveChanges();
                accion = true;
            }
            catch (Exception)
            {
                accion = false;
            }
            return accion;
        }


        public Proveedores ObtenerId(int idProveedor)
        {
            var model = contexto.Proveedores.FirstOrDefault(x => x.IdProveedor == idProveedor);

            return model;
        } 

        public bool Delete(int idProveedor)
        {
            bool accion;
            var model = ObtenerId(idProveedor);

            if (model != null)
            {
                try
                {
                    contexto.Entry(model).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    accion = true;
                }
                catch (Exception)
                {
                    accion = false;
                }
            }
            else
            {
                accion = false;
            }
            return accion;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
