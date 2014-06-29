﻿using System;
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
                name: "Log",
                url: "log/{src}/{content}",
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
