using BAL.Iservices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace BAL.Services
{
    public class ClientesRepository : IClientesRepository, IDisposable
    {

        private readonly Contexto contexto;

        public ClientesRepository(Contexto contexto_)
        {
            this.contexto = contexto_;
        }

        public bool AgregarEditar(Clientes model)
        {
            bool hecho;
            try
            {
                if (model.IdCliente > 0)
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


        public Clientes ObtenerId(int IdClien)
        {
            var model = contexto.Clientes.FirstOrDefault(x => x.IdCliente == IdClien);

            return model;
        }

        public bool EliminarCliente(int IdClien)
        {
            bool hecho;
            var model = ObtenerId(IdClien);
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
