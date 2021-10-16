using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BAL.Services
{
    public class ModelosRepository : IModelosRepository
    {

        private readonly Contexto contexto;

        public ModelosRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public bool AgregarOEditModelo(Modelos modelo)
        {
            bool success;

            try
            {
                if(modelo.IdModelo > 0)
                {
                    contexto.Entry(modelo).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(modelo).State = EntityState.Added;
                }


                success = true;
                contexto.SaveChanges();

            }
            catch (Exception)
            {
                success = false;
                throw new Exception("Esa mierda no guarda Tilin");
            }

            return success;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool EliminarModelo(int IdModelo)
        {
            bool success;
            var model = ObtenerModeloPorId(IdModelo);

            if (model != null)
            {
                try
                {
                    contexto.Entry(model).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
                catch (Exception)
                {
                    success = false;
                    throw new Exception();
                }
            }
            else
            {
                success = false;
            }
            
            return success;
        }

        public Modelos ObtenerModeloPorId(int IdModelo)
        {

            var model = contexto.Modelos.FirstOrDefault(x => x.IdModelo == IdModelo);

            return model;

        }

        public IEnumerable<Modelos> ObtenerModelos()
        {

            var modelos = contexto.Modelos.ToList();

            return modelos;
        }
    }
}
