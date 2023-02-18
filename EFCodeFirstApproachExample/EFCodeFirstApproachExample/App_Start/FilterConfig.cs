using EFCodeFirstApproachExample.Filters;
using System;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthenticationFilter());
            filters.Add(new ExceptionFilter());
            //filters.Add(new HandleErrorAttribute());    
            //filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception) , View = "Error"});    
        }
    }
}
