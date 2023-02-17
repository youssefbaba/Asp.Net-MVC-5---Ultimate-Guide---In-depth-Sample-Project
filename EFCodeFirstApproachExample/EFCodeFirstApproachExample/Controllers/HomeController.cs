using EFCodeFirstApproachExample.Filters;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    [CustomerAuthorizationFilter]
    public class HomeController : Controller
    {
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