using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    public class HomeController : Controller
    {
        [OverrideAuthentication]
        [HttpGet]
        // GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}