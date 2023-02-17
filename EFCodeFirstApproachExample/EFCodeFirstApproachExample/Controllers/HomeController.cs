using EFCodeFirstApproachExample.Filters;
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
            ViewBag.NumberOfVisitorsPerDay = 100; 
            return View();
        }
    }
}