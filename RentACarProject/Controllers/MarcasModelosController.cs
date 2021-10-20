using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Entity;
using BAL.Services;
using BAL.IServices;
using RentACarProject.Security;

namespace RentACarProject.Controllers
{
    [Permisos]
    [Admin]
    public class MarcasModelosController : Controller
    {
        private IMarcasRepository marcasRepository;
        private IModelosRepository modelosRepository;

        public MarcasModelosController()
        {
            this.marcasRepository = new MarcasRepository(new Contexto());
            this.modelosRepository = new ModelosRepository(new Contexto());
        }

        // GET: MarcasModelos
        public ActionResult Index()
        {
            return View();
        }

        //Crud marcas, modelos y tipos de autos
        public ActionResult GetMarcasModelos(bool? marcaEliminada, bool? modeloEliminado)
        {

            if (marcaEliminada.HasValue)
            {
                ViewBag.MarcaEliminada = marcaEliminada.Value;
            }

            if (modeloEliminado.HasValue)
            {
                ViewBag.ModeloEliminado = modeloEliminado.Value;
            }

            var marcas = marcasRepository.ObtenerMarcas();

            ViewBag.MarcasLista = marcas;

            var modelos = modelosRepository.ObtenerModelos();
            ViewBag.ModelosLista = modelos;

            return View();
        }
        
        [HttpGet]
        public ActionResult CrearMarca(int IdMarca=0)
        {

            Marcas marca = new Marcas();

            if(IdMarca > 0)
            {
                marca = marcasRepository.ObtenerMarcaPorId(IdMarca);
                ViewBag.editar = true;
                ViewBag.IdLogo = IdMarca;
            }
            else
            {
                ViewBag.editar = false;
            }

            return PartialView("PartialViews/MarcasPartialView", marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearMarca(Marcas marca, HttpPostedFileBase file)
        {
            Marcas _marca = new Marcas();
            Contexto contexto = new Contexto();
            file = Request.Files[0];

            if (file.ContentLength != 0) { 

                WebImage LogoMarca = new WebImage(file.InputStream);
                marca.LogoMarca = LogoMarca.GetBytes();
            }
            else
            {
                _marca = contexto.Marcas.Find(marca.IdMarca);

                marca.LogoMarca = _marca.LogoMarca;

                contexto.Entry(_marca).State = EntityState.Detached;
            }

            try
            {

                var MarcaCreada = marcasRepository.AgregarOEditMarca(marca);

                if (MarcaCreada)
                {
                    ViewBag.success = "Marca de vehículo ingresada con éxito";
                    return RedirectToAction("GetMarcasModelos");
                }

            }
            catch (Exception e)
            {
                
                throw new Exception("Ha ocurrido un error!" + e.Message);
            }
            

            return RedirectToAction("GetMarcasModelos");
        }

        [HttpGet]
        public ActionResult CrearModelo(int IdModelo=0)
        {

            Modelos modelo = new Modelos();

            if (IdModelo > 0)
            {
                modelo = modelosRepository.ObtenerModeloPorId(IdModelo);
                ViewBag.editar = true;
            }
            else {
                ViewBag.editar = false;
            }

            List<SelectListItem> Marcas = new List<SelectListItem>();
            var listaMarcas = marcasRepository.ObtenerMarcas();

            foreach(var marca in listaMarcas)
            {
                Marcas.Add(new SelectListItem() { Text= marca.NombreMarca, Value= marca.IdMarca.ToString() });
            }
            

            ViewBag.ListaMarcas = Marcas;
            

            return PartialView("PartialViews/ModelosPartialView", modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearModelo(Modelos modelo)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var modeloCreado = modelosRepository.AgregarOEditModelo(modelo);

                    if (modeloCreado)
                    {
                        ViewBag.success = "Modelo de vehículo creado con éxito";
                        return RedirectToAction("GetMarcasModelos");
                    }
                }
             
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                
            }

            return RedirectToAction("GetMarcasModelos");
        }


        public ActionResult EliminarMarca(int IdMarca)
        {
            bool success = false;

            try
            {
                var modelos = modelosRepository.ObtenerModelos();

                foreach(var modelo in modelos)
                {
                    if(modelo.FkMarca == IdMarca)
                    {
                        modelosRepository.EliminarModelo(modelo.IdModelo);
                    }
                }

                var MarcaEliminada = marcasRepository.EliminarMarca(IdMarca);

                if (MarcaEliminada)
                {
                    success = true;
                }

            }
            catch (Exception e)
            {

                throw new Exception("Error:"+e.Message);
            }


            return RedirectToAction("GetMarcasModelos", new { marcaEliminada = success });
        }

        public ActionResult EliminarModelo(int IdModelo)
        {
            bool success = false;
            try
            {
                var ModeloEliminado = modelosRepository.EliminarModelo(IdModelo);

                if (ModeloEliminado)
                {
                    success = true;
                }

            }catch(Exception e)
            {
                ModelState.AddModelError("Ocurrio un error al intentar borrar el modelo. Error:", e.Message);
            }

            return RedirectToAction("GetMarcasModelos", new { modeloEliminado = success });
        }

        public ActionResult ConvertirImagen(int id)
        {
            Marcas marca = marcasRepository.ObtenerMarcaPorId(id);

            byte[] ByteImagen = marca.LogoMarca;
            MemoryStream memoryStream = new MemoryStream(ByteImagen);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;

            
            return File(memoryStream, "image/png");
        }

    }
}