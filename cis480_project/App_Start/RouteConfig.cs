using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET_MVC5_Bootstrap3_3_1_LESS {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:   "Enabling Obectives",
                url:    "Course/{courseId}/Objective/{objectiveId}/EnablingObjective/{action}/{enablingObjectiveId}",
                defaults: new { controller = "EnablingObjective", action = "Index", enablingObjectiveId = UrlParameter.Optional}

    );
            routes.MapRoute(
                name: "Objectives",
                url: "Course/{courseId}/Objective/{action}/{objectiveId}",
                defaults: new { controller = "Objective", action="Index", objectiveId = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}