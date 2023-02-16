using EFCodeFirstApproachExample.Identity;
using EFCodeFirstApproachExample.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _db;

        public AccountController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpGet]
        // GET: /Account/Register
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        // POST: /Account/Register
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration
                var userStore = new ApplicationUserStore(_db);
                var userManager = new ApplicationUserManager(userStore);
                var user = new ApplicationUser();
                user.UserName = model.UserName;
                user.PasswordHash = Crypto.HashPassword(model.Password);
                user.Email = model.Email;
                user.PhoneNumber = model.Mobile;
                user.BirthDay = model.BirthDay;
                user.Country = model.Country;
                user.City = model.City;
                user.Address = model.Address;
                var checkUser = userManager.Create(user);
                if (checkUser.Succeeded)
                {
                    // Add Role
                    userManager.AddToRole(user.Id, "Customer");

                    // Login
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("My Error", "The registration attempt failed");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Data");
                return View(model);
            }
        }

        [HttpGet]
        // GET: /Account/Login
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        // POST: /Account/Login
        public ActionResult Login(LoginViewModel model)
        {
            var userStore = new ApplicationUserStore(_db);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("My Error", "Invalid UserName or Password");
                return View(model);
            }
            else
            {
                // Login
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        // GET: /Account/Logout
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        // GET: /Account/Profile
        public new ActionResult Profile()
        {
            var userStore = new ApplicationUserStore(_db);
            var userManager = new ApplicationUserManager(userStore);
            var userId = User.Identity.GetUserId();
            var currentUser = userManager.FindById(userId);
            ViewBag.PreviousUrl = Request.UrlReferrer.ToString();
            return View(currentUser);
        }
    }
}