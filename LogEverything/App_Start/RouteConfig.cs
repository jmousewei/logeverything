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
                name: "Trigger",
                url: "trigger",
                defaults: new { controller = "Log", action = "Trigger" }
            );

            routes.MapRoute(
                name: "Log",
                url: "log/{content}",
                defaults: new { controller = "Log", action = "Write" }
            );

            routes.MapRoute(
                name: "Home",
                url: "{*url}",
                defaults: new { controller = "Log", action = "Index" }
            );
        }
    }
}
