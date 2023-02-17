using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Filters
{
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)  // It Is executed before executing of the current action method
        {
            filterContext.Controller.ViewBag.NumberOfVisitorsPerDay = 150;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)   // It will execute after executing of the current action method
        {
            filterContext.Controller.ViewBag.NumberOfVisitorsPerDay = 200;
        }

    }
}  