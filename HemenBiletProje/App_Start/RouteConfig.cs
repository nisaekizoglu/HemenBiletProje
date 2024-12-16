using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HemenBiletProje
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(



       name: "FlightRoute",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "Flight", action = "Index", id = UrlParameter.Optional },
       namespaces: new[] { "HemenBiletProje.Controllers" } // Hangi namespace kullanılacaksa onu ekleyin
   );

            // Varsayılan Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HemenBiletProje.Controllers" }
            );
        }
    }
}
