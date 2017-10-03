using Nop.Web.Framework.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Nop.Plugin.Misc.AdminOverride
{
    public class AdminOverrideViewEngine : ThemeableRazorViewEngine
    {
        private static readonly string[] _emptyLocations = new string[0];

        public AdminOverrideViewEngine()
        {
            var loaction = new[] { "~/Plugins/Misc.AdminOverride/Views/{1}/{0}.cshtml",
                "~/Plugins/Misc.AdminOverride/Views/Shared/{0}.cshtml",
                "~/Plugins/Misc.AdminOverride/Administration/Views/{1}/{0}.cshtml" };
            PartialViewLocationFormats = loaction;
            ViewLocationFormats = loaction;
        }

        protected override string GetPath(ControllerContext controllerContext, string[] locations, string[] areaLocations, string locationsPropertyName, string name, string controllerName, string theme, string cacheKeyPrefix, bool useCache, out string[] searchedLocations)
        {
            searchedLocations = _emptyLocations;
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            string areaName = GetAreaName(controllerContext.RouteData);
            bool usingAreas = !string.IsNullOrEmpty(areaName);
            List<ViewLocation> viewLocations = GetViewLocations(locations, usingAreas ? areaLocations : null);

            bool nameRepresentsPath = IsSpecificPath(name);
            string cacheKey = this.CreateCacheKey(cacheKeyPrefix, name, nameRepresentsPath ? string.Empty : controllerName, areaName, theme);
            if (useCache)
            {
                var cached = this.ViewLocationCache.GetViewLocation(controllerContext.HttpContext, cacheKey);
                if (cached != null)
                {
                    return cached;
                }
            }

            if (!nameRepresentsPath)
            {
                return this.GetPathFromGeneralName(controllerContext, viewLocations, name, controllerName, areaName, theme, cacheKey, ref searchedLocations);
            }

            return this.GetPathFromSpecificName(controllerContext, name, cacheKey, ref searchedLocations);
        }
    }
}
