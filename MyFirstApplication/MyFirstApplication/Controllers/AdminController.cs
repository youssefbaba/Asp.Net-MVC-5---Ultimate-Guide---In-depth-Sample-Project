using System.Web.Mvc;

namespace MyFirstApplication.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        // GET: /admin/dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        // GET: /admin/contact
        public ActionResult Contact()
        {
            ViewBag.Phone = "456-456-456";
            return View();
        }
    }
}