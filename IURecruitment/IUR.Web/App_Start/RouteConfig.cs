using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IUR.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Apply Form",
                url: "apply/job-{jobid}",
                defaults: new { controller = "Application", action = "ApplyForm", id = UrlParameter.Optional },
                namespaces: new string[] { "IUR.Web.Controllers" }
            );

            routes.MapRoute(
                name: "How To Apply",
                url: "how-to-apply",
                defaults: new { controller = "Home", action = "HowToApply", id = UrlParameter.Optional },
                namespaces: new string[] { "IUR.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Job Listing",
                url: "job-listing",
                defaults: new { controller = "Job", action = "JobListing", id = UrlParameter.Optional },
                namespaces: new string[] { "IUR.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "IUR.Web.Controllers" }
            );
        }
    }
}
