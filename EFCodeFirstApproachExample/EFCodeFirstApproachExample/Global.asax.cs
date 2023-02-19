using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFCodeFirstApproachExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            var message = exception.Message;
            var type = exception.GetType().ToString();
            var source = exception.Source;
            var date = DateTime.Now;
            var logText = $"Date = {date}\nMessage = {message}\nType = {type}\nSource = {source}\n";
            using (StreamWriter sw = File.AppendText($"{HttpContext.Current.Request.PhysicalApplicationPath}\\ErrorLog.txt"))
            {
                sw.WriteLine(logText);
            }
            Server.ClearError();
            Response.Redirect("~/Error.html");
        }
    }
}
