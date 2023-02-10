using System.Web.Mvc;

namespace MyFirstApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: /admin/dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}