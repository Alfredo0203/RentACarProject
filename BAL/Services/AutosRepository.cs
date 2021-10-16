using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BAL.Services
{
    public class AutosRepository : IAutosRepository, IDisposable
    {
        //VARIABLE CONTEXTO
        private readonly Contexto contexto;

        //CONSTRUCTOR
        public AutosRepository(Contexto c)
        {
            this.contexto = c;
        }

        //<<<<<<<<<<<<<<<IMPLEMENTACION DE METODOS>>>>>>>>>>>>>>>>>
        
        //LISTAR AUTOS
        public List<Autos> listarAutos()
        {
            var Autos = contexto.Autos.ToList();
            return Autos;
        }

        //OBTENER AUTOS POR ID
        public Autos ObtenerPorId(int id)
        {
            var auto = contexto.Autos.FirstOrDefault(x => x.IdAuto == id);
            return auto;
        }

        //EDITAR O AGREGAR AUTOS
        public void EditarOAgregarAutos(Autos autos)
        {
            if (autos.IdAuto > 0)
            {
                contexto.Entry(autos).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                contexto.Entry(autos).State = System.Data.Entity.EntityState.Added;
            }
            contexto.SaveChanges();
        }

        //ELIMINAR AUTOS
        public void EliminarAuto(int id)
        {
            var auto = ObtenerPorId(id);
            if (auto != null)
            {
                contexto.Entry(auto).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
