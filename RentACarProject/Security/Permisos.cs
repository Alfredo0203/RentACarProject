using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RentACarProject.Security
{
    public class Permisos: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var Id = System.Web.HttpContext.Current.Session["IdAdministrador"];
            var id_string = "0";

            if (Id != null)
            {
                id_string = Id.ToString();
            }
            if (!PermisoPorRol.IsAdmin(int.Parse(id_string)))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Error"
                }));
            }
        }
    }

    public class PermisoPorRol
    {
        public static bool IsAdmin(int idAdmin)
        {
            if (idAdmin <= 0)
            {
                return false;
            }
            using (var contexto = new Contexto())
            {
                var User = contexto.Administradores.FirstOrDefault(x => x.IdAdministrador == idAdmin);
                return User.Rol == Roles.admin ? true : false;

            }
        }
    }
}