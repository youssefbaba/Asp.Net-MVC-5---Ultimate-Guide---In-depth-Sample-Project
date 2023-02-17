using EFCodeFirstApproachExample.Filters;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    [CustomerAuthorizationFilter]
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