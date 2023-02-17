using Glimpse.AspNet.Tab;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Admin_default",
               url: "Admin/{controller}/{action}/{id}",
               defaults: new { action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "EFCodeFirstApproachExample.Areas.Admin.Controllers" }
            );
        }
    }
}