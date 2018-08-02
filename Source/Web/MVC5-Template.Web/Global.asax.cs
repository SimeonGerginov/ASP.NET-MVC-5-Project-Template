using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using MVC5_Template.Web.Infrastructure.Configs;

namespace MVC5_Template.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var assembly = Assembly.GetExecutingAssembly();
            var mapper = new AutoMapperConfig(assembly);

            mapper.Execute();
        }
    }
}
