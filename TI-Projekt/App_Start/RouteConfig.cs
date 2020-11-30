using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TI_Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "Details",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Details", action = "Details" }
            );

            routes.MapRoute(
                name: "NewForm",
                url: "{controller}/{action}/",
                defaults: new { controller = "Form", action = "AddNewInfo" }
            );

            routes.MapRoute(
                name: "Form",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Form", action = "AddInfo", id = UrlParameter.Optional }
            );
        }
    }
}
