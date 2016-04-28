﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodHunterAlpha
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Store",
                url: "store/{name}/{action}/{id}",
                defaults: new { controller = "Customer", action = "StoreHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "customer",
              url: "{action}/{id}",
              defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
