using BAL.IServices;
using BAL.Services;
using DAL.Models;
using RentACarProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACarProject.Controllers
{
    [Permisos]
    [Admin]
    public class AdministradoresController : Controller
    {
        // GET: Administradores
        
            Contexto contexto = new Contexto();

            private IAdministradoresRepository administradoresRepository;

            public AdministradoresController()
            {
                this.administradoresRepository = new AdministradoresRepository(new Contexto());
            }

            public ActionResult MostrarAdministradores()
            {
                var model = contexto.Administradores.ToList();

                return View(model);
            }
            public ActionResult AddOrEdit(int IdAdmin = 0)
            {
                var model = new Administradores();

                if (IdAdmin > 0)
                {
                    model = administradoresRepository.ObtenerId(IdAdmin);
                }
                return View(model);
            }
            [HttpPost]
            public ActionResult AddOrEdit(Administradores model)
            {
                if (ModelState.IsValid)
                {
                model.Contra= Encriptado.EncryptPassword(model.Contra);
                model.Rol = Roles.admin;
                    var hecho = administradoresRepository.AgregarEditar(model);
                    if (hecho)
                    {
                        return RedirectToAction("MostrarAdministradores");
                    }
                }
                return View(model);
            }

            public ActionResult EliminarAdmin(int IdAdmin)
            {
                var hecho = administradoresRepository.EliminarAdmin(IdAdmin);

                return RedirectToAction("MostrarAdministradores");
            }
        }
    }
