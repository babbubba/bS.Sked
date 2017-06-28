using bs.Sked.Mapping;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace bS.Sked.WMC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CompositionRootConfig.RegisterComponents();
            Mapping.RegisterMappings();
            CompositionRoot.CompositionRoot.Instance().Resolve<Services.WMC.DatabaseManagerService>().InitOrUpdateDatabase();

        }
    }
}
