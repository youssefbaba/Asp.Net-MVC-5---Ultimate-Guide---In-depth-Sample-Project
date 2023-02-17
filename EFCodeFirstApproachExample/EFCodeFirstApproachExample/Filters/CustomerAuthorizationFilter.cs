using EFCodeFirstApproachExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Filters
{
    public class CustomerAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole(UserRoles.Customer))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}