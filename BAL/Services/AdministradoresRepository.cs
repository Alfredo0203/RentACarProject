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
    public class AdministradoresRepository : IAdministradoresRepository, IDisposable
    {

        private readonly Contexto contexto;

        public AdministradoresRepository(Contexto contexto_)
        {
            this.contexto = contexto_;
        }
        public bool AgregarEditar(Administradores model)
        {
            bool hecho;
            try
            {
                if (model.IdAdministrador > 0)
                {
                    contexto.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(model).State = EntityState.Added;
                }

                contexto.SaveChanges();
                hecho = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e);
                hecho = false;
            }

            return hecho;
        }

        public Administradores ObtenerId(int IdAdmin)
        {
            var model = contexto.Administradores.FirstOrDefault(x => x.IdAdministrador == IdAdmin);

            return model;
        }
        public bool EliminarAdmin(int IdAdmin)
        {
            bool hecho;
            var model = ObtenerId(IdAdmin);
            if (model != null)
            {
                try
                {
                    contexto.Entry(model).State = EntityState.Deleted;

                    contexto.SaveChanges();
                    hecho = true;
                }
                catch (Exception)
                {

                    hecho = false;
                }
            }
            else
            {
                hecho = false;
            }

            return hecho;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
