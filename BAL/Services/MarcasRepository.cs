using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BAL.Services
{
    public class MarcasRepository : IMarcasRepository
    {

        private readonly Contexto contexto;

        public MarcasRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public bool AgregarOEditMarca(Marcas model)
        {
            bool success;

            try
            {
                if(model.IdMarca > 0)
                {
                    
                    contexto.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(model).State = EntityState.Added;
                }

                contexto.SaveChanges();
                success = true;

            }catch(Exception ex)
            {
                success = false;
                throw new Exception();
            }

            return success;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool EliminarMarca(int IdMarca)
        {
            bool success;
            var model = ObtenerMarcaPorId(IdMarca);

            if(model != null)
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
                    throw new Exception("No se pudo borrar la marca, intente de nuevo!");
                }
            }else
            {
                success = false;
            }

            return success;
        }

        public Marcas ObtenerMarcaPorId(int IdMarca)
        {

            var model = contexto.Marcas.FirstOrDefault(x => x.IdMarca == IdMarca);

            return model;

        }

        public IEnumerable<Marcas> ObtenerMarcas()
        {
            
            var marcas = contexto.Marcas.ToList();

            return marcas;
        }


    }
}
