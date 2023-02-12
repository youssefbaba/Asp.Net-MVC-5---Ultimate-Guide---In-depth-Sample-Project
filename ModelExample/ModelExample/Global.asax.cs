using ModelExample.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace ModelExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Student), new CustomBinder());
        }
    }
}
