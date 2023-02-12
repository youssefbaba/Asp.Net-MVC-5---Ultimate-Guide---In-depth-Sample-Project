using System.Collections.Generic;
using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Home/Index")]
        [Route("")]  // Default Route
        // GET: /Home/Index
        public ActionResult Index()
        {
            ViewBag.Message1 = "Welcome To Demo Application";
            return View();
        }

        [ChildActionOnly]
        [Route("Home/DemoPartialView")]
        public ActionResult DemoPartialView()
        {
            ViewBag.ListTitle = "Home : ";
            ViewBag.Items = new List<string>() { "Admin Home", "Agent Home", "Customer Home" };
            return PartialView("_ListPartialView");
        }

        [HttpGet]
        [Route("Home/About")]
        // GET: /Home/About
        public ActionResult About()
        {
            ViewBag.Message1 = "Leading Company In The World";
            return View();
        }

        [HttpGet]
        [Route("Home/Contact")]
        // GET: /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message1 = "Contact Our Customer Care Representative";
            return View();
        }

        [HttpGet]
        [Route("Home/Profile")]
        // GET: /Home/Profile
        public new ActionResult Profile()
        {
            return View();
        }
    }
}