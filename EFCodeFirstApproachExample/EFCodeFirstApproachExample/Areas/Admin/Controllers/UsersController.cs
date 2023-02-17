using EFCodeFirstApproachExample.Areas.Admin.ViewModels;
using EFCodeFirstApproachExample.Identity;
using EFCodeFirstApproachExample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EFCodeFirstApproachExample.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _db;

        public UsersController()
        {
            _db = new ApplicationDbContext();
        }


        [HttpGet]
        // GET: /Admin/Users
        public ActionResult Index(int currentPage = 1)
        {
            var userStore = new ApplicationUserStore(_db);
            var userManager = new ApplicationUserManager(userStore);
            var users = userManager.Users.ToList();  // List of users
            var roles = new List<List<string>>();
            foreach (var user in users)
            {
                var rolesPerUser = userManager.GetRoles(user.Id).ToList();
                roles.Add(rolesPerUser);
            }

            // Pagination
            var numberOfItemsPerPage = 5;
            var numberOfPages = Convert.ToInt32((Math.Ceiling(Convert.ToDouble(users.Count) / Convert.ToDouble(numberOfItemsPerPage))));
            ViewBag.currentPage = currentPage;
            ViewBag.numberOfPages = numberOfPages;
            users = users.Skip((currentPage - 1) * numberOfItemsPerPage).Take(numberOfItemsPerPage).ToList();

            var viewModel = new UserViewModel()
            {
                users = users,
                roles = roles
            };

            return View(viewModel);
        }
    }
}