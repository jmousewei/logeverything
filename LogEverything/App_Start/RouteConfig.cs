using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LogEverything
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "QQ",
                url: "qq",
                defaults: new { controller = "QQ", action = "Index" }
            );

            routes.MapRoute(
                name: "QQInfo",
                url: "qq/info",
                defaults: new { controller = "QQ", action = "Info" }
            );

            routes.MapRoute(
                name: "Redirect",
                url: "redirect",
                defaults: new { controller = "Redirect", action = "Index" }
            );

            routes.MapRoute(
                name: "Home",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
