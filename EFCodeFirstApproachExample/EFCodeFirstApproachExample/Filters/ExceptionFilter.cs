using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var message = filterContext.Exception.Message;
            var type = filterContext.Exception.GetType().ToString();
            var source = filterContext.Exception.Source;
            var date = DateTime.Now;
            var logText = $"Date = {date}\nMessage = {message}\nType = {type}\nSource = {source}\n";
            using (StreamWriter sw = File.AppendText($"{filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath}\\ErrorLog.txt"))
            {
                sw.WriteLine(logText);
            }
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("~/Error.html");
        }
    }
}