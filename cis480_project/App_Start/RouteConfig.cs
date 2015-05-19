using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Courses",
            //    url: "campus/{campusId}/course/{id}",
            //    defaults: new { controller = "Course", action = "Index", id = UrlParameter.Optional}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}