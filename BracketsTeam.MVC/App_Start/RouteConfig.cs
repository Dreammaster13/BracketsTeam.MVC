using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BracketsTeam.MVC
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

           /*routes.MapRoute(
                name: "Brackets",
                url: "Brackets/",
                defaults: new { controller = "Brackets", action = "Index", id = UrlParameter.Optional }
            );*/

            routes.MapRoute(
                name: "Team",
                url: "Team/{action}/{id}",
                defaults: new { controller = "Team", action = "{action}", id = UrlParameter.Optional }
            );
        }
    }
}
