using EFCodeFirstApproachExample.Filters;
using System;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 30)]
        [OverrideAuthentication]
        [ActionFilter]
        [ResultFilter]
        [HttpGet]
        // GET: /Home/Index
        public ActionResult Index()
        {
            //throw new Exception("Some Exception For Testing Purpose");
            ViewBag.NumberOfVisitorsPerDay = 100; 
            return View();
        }
    }
}