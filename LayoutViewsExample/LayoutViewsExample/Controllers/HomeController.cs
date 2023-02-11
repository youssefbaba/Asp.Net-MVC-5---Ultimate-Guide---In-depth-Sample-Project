using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /home/index
        public ActionResult Index()
        {
            ViewBag.Message1 = "Welcome To Demo Application";
            return View();
        }

        [HttpGet]
        // GET: /home/about
        public ActionResult About()
        {
            ViewBag.Message1 = "Leading Company In The World";
            return View();
        }

        [HttpGet]
        // GET: /home/contact
        public ActionResult Contact()
        {
            ViewBag.Message1 = "Contact Our Customer Care Representative";
            return View();
        }

        [HttpGet]
        // GET: /home/profile
        public new ActionResult Profile()
        {
            return View();
        }
    }
}