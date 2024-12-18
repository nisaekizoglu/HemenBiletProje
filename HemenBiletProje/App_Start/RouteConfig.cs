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
            name: "AdminPanel", // Benzersiz bir isim verin
            url: "admin/{action}/{id}",
            defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "FlightRoute",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Flight", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HemenBiletProje.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "HemenBiletProje.Controllers" }
            );

        }
    }
}
