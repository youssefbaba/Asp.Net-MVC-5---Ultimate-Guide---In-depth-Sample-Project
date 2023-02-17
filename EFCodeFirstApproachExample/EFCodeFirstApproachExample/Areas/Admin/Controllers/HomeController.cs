using EFCodeFirstApproachExample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorizationFilter]
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /Admin/Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}