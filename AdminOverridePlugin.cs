using Nop.Core.Plugins;
using Nop.Services.Common;
using System.Web.Routing;

namespace Nop.Plugin.Misc.AdminOverride
{
    public class AdminOverridePlugin : BasePlugin, IMiscPlugin
    {
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "AdminOverrideAdmin";
            routeValues = new RouteValueDictionary()
            {
                { "Namespaces", "Nop.Plugin.Misc.AdminOverride.Controllers" },
                { "area", null }
            };

        }
    }
}
