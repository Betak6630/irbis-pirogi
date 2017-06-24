using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Irbis
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Pies", "pies", new { controller = "Category", action = "Index", productTypeId = "1", area = "" });
            routes.MapRoute("SweetPies", "SweetPies", new { controller = "Category", action = "Index", productTypeId = "2", area = "" });
            routes.MapRoute("LeanPies", "LeanPies", new { controller = "Category", action = "Index", productTypeId = "3", area = "" });

            routes.MapRoute("Delivery", "delivery", new { controller = "Home", action = "Delivery",  area = "" });
            routes.MapRoute("About", "about", new { controller = "Home", action = "About",  area = "" });
            routes.MapRoute("Contact", "contact", new { controller = "Home", action = "Contact",  area = "" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
