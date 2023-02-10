using System.Web.Mvc;

namespace MyFirstApplication.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        // GET: /account/login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // POST:
        public ActionResult Login(string userName, string passWord)
        {
            if (userName == "admin" && passWord == "manager")
            {
                return RedirectToAction("Dashboard", "Admin");
            };
            return RedirectToAction("InvalidLogin");
        }

        [HttpGet]
        // GET: /account/invalidlogin
        public ActionResult InvalidLogin()
        {
            return View();
        }
    }
}