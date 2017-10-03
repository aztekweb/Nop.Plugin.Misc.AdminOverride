using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Misc.AdminOverride
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            ViewEngines.Engines.Insert(0, new AdminOverrideViewEngine());
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
