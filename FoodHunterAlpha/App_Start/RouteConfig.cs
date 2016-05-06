using System;
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


            /* --- counter --- */
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "counter",
              url: "counter/{action}/{id}",
              defaults: new { controller = "Counter", action = "Index", id = UrlParameter.Optional }
            );

            /* --- customer --- */
            //brand
            routes.MapRoute(
              name: "brand",
              url: "brand/{nameId}/{action}",
              defaults: new { controller = "Brand", action = "Home", id = UrlParameter.Optional }
            );

            //store
            routes.MapRoute(
                name: "store",
                url: "store/{nameId}/{action}/{id}",
                defaults: new { controller = "Store", action = "Home", id = UrlParameter.Optional }
            );

            //store
            routes.MapRoute(
                name: "account",
                url: "account/{action}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );


            //platform
            routes.MapRoute(
             name: "platform",
             url: "{action}/{id}",
             defaults: new { controller = "Platform", action = "Home", id = UrlParameter.Optional }
           );
        }
    }
}
