using System.Web.Mvc;
using System.Web.Routing;
using Manpower.CustomerPortal.Web.Classes;

namespace Manpower.CustomerPortal.Web
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ViewEngines.Engines.Add(new SeparatedPathViewEngine());

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }
        protected override void RegisterRoutes(RouteCollection routes)
        {
            base.RegisterRoutes(routes);

            RouteTable.Routes.MapRoute(name: "mvc",
                url: "mvc/{controller}/{action}/{id}",
                defaults: new { action = "index", id = UrlParameter.Optional });

        }
    }
}