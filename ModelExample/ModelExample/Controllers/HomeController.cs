using System.Web.Mvc;

namespace ModelExample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: /Home/About
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        // GET: /Home/Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        // GET: /Home/Profile
        public new ActionResult Profile()
        {
            return View();
        }
    }
}