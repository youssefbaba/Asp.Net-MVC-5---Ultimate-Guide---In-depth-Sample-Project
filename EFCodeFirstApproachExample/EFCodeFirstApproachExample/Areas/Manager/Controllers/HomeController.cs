using EFCodeFirstApproachExample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Areas.Manager.Controllers
{
    [ManagerAuthorizationFilter]
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /Manager/Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}