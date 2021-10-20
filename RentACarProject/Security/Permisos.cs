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

            var UserId = HttpContext.Current.Session["UserId"];

            if (UserId == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = "IniciarSesion",
                        action = "IniciarSesion"
                    }
                    ));
            }

        }


    }

    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            var RolUser = HttpContext.Current.Session["UserRol"];

            using (Contexto db = new Contexto())
            {
                if (RolUser.Equals("cliente"))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                       new
                       {
                           controller = "Home",
                           action = "Error"
                       }
                       ));

                }

            }
        }

    }

    public class Cliente : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var RolUser = HttpContext.Current.Session["UserRol"];

            using (Contexto db = new Contexto())
            {

                if (RolUser.Equals("administrador"))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                       new
                       {
                           controller = "Home",
                           action = "Error"
                       }
                       ));

                }

            }
        }

    }
}


