using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BundlingAndMinification.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}