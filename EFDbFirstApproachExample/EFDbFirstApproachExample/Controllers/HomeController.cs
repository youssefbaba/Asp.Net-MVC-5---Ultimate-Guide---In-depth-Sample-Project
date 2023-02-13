using System.Web.Mvc;

namespace EFDbFirstApproachExample.Controllers
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