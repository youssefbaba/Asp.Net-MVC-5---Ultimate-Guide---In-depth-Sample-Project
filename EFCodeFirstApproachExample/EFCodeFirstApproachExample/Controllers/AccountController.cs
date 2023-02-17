using EFCodeFirstApproachExample.Filters;
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

        [OverrideAuthentication]
        [ActionName("Register")]
        [HttpGet]
        // GET: /Account/Register
        public ActionResult RegistrationPage()
        {
            var viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        [OverrideAuthentication]
        [HttpPost]
        // POST: /Account/Register
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    PasswordHash = Crypto.HashPassword(model.Password),
                    Email = model.Email,
                    PhoneNumber = model.Mobile,
                    BirthDay = model.BirthDay,
                    Country = model.Country,
                    City = model.City,
                    Address = model.Address,
                };
                var checkUser = GetUserManager().Create(user);
                if (checkUser.Succeeded)
                {
                    // Add Role
                    GetUserManager().AddToRole(user.Id, "Customer");

                    // Login
                    HelperForLogin(user);
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

        [ActionName("Login")]
        [OverrideAuthentication]
        [HttpGet]
        // GET: /Account/Login
        public ActionResult LoginPage()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [OverrideAuthentication]
        [HttpPost]
        // POST: /Account/Login
        public ActionResult Login(LoginViewModel model)
        {
            var user = GetUserManager().Find(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("My Error", "Invalid UserName or Password");
                return View(model);
            }
            else
            {
                // Login
                HelperForLogin(user);
                if (GetUserManager().IsInRole(user.Id, UserRoles.Admin))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (GetUserManager().IsInRole(user.Id, UserRoles.Manager))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
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

        [CustomerAuthorizationFilter]
        [HttpGet]
        // GET: /Account/Profile
        public new ActionResult Profile()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = GetUserManager().FindById(userId);
            ViewBag.PreviousUrl = Request.UrlReferrer.ToString();
            return View(currentUser);
        }

        [NonAction]
        private ApplicationUserManager GetUserManager()
        {
            var userStore = new ApplicationUserStore(_db);
            var userManager = new ApplicationUserManager(userStore);
            return userManager;
        }

        [NonAction]
        private void HelperForLogin(ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = GetUserManager().CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
    }
}