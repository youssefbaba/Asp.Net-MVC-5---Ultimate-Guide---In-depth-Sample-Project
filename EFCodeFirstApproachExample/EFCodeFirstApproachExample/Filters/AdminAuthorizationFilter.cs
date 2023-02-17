using EFCodeFirstApproachExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Filters
{
    public class AdminAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole(UserRoles.Admin))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}