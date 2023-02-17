using EFCodeFirstApproachExample.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Areas.Manager.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _db;

        public AccountController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpGet]
        // GET: /Manager/Account/Profile
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