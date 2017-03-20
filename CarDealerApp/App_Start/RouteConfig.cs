using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //2
            //routes.MapRoute(
            //    name: "Cars",
            //    url: "{cars}/{make}",
            //    defaults: new { controller = "Cars", action = "Index" },
            //    
            //);

            //1
            //routes.MapRoute(
            //    name: "All customers",
            //    url: "{customers}/{all}/{order}",
            //    defaults: new { controller = "Customers", action = "All", order = "ascending" },
            //    constraints: new { order = @"ascending|descending" }
            //    );

            //3
            //routes.MapRoute(
            //   name: "Suppliers filtered",
            //   url: "{suppliers}/{type}",
            //   defaults: new { controller = "Suppliers", action = "Index" }
            //   );

            //4
            //routes.MapRoute(
            //   name: "Car with parts",
            //   url: "cars/{id}/parts",
            //   defaults: new { controller = "Cars", action = "CarParts" },
            //   constraints: new {id=@"\d+"}
            //   );

            //6
            ////routes.MapRoute(
            ////   name: "All sales",
            ////   url: "sales",
            ////   defaults: new { controller = "Sales", action = "All" }
            ////   );


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
