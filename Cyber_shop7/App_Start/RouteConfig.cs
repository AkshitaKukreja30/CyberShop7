using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cyber_shop7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Foods",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Foods", id = UrlParameter.Optional }
            );
         /*  routes.MapRoute(
                name: "Foods",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Foods", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Clothings",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Clothings", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Books",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Books", id = UrlParameter.Optional }
            );

    */
        }
    }
}
