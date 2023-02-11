using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: /home/index
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: /home/about
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        // GET: /home/contact
        public ActionResult Contact()
        {
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