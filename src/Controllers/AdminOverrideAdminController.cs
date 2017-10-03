using Nop.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nop.Plugin.Misc.AdminOverride.Controllers
{
    public class AdminOverrideAdminController : BasePublicController
    {
        public ActionResult Configure()
        {
            return View("~/Plugins/Misc.AdminOverride/Views/Configure.cshtml");
        }
    }
}
