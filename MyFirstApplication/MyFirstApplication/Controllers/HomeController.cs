using System.Web.Mvc;

namespace MyFirstApplication.Controllers
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
        // GET: /home/products
        public ActionResult products()
        {
            return View("OurCompanyProducts");
        }

        [HttpGet]
        // GET: /home/contact
        public ActionResult contact()
        {
            return View();
        }
    }
}