using EFCodeFirstApproachExample.Identity;
using EFCodeFirstApproachExample.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(EFCodeFirstApproachExample.Startup))]

namespace EFCodeFirstApproachExample
{
    public class Startup
    {
        private ApplicationDbContext _db;

        public Startup()
        {
            _db = new ApplicationDbContext();
        }

        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            CreateRolesAndUsers();
        }

        // Temporary Code
        private void CreateRolesAndUsers()
        {
            var roleStore = new RoleStore<IdentityRole>(_db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new ApplicationUserStore(_db);
            var userManager = new ApplicationUserManager(userStore);

            // Create Admin Role
            if (!roleManager.RoleExists(UserRoles.Admin))
            {
                var role = new IdentityRole();
                role.Name = UserRoles.Admin;
                roleManager.Create(role);
            }

            // Create Admin User
            if (userManager.FindByName("admin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                user.PasswordHash = Crypto.HashPassword("admin123");
                var checkUser = userManager.Create(user);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, UserRoles.Admin);
                }
            }

            // Create Manager Role
            if (!roleManager.RoleExists(UserRoles.Manager))
            {
                var role = new IdentityRole();
                role.Name = UserRoles.Manager;
                roleManager.Create(role);
            }

            // Create Manager User
            if (userManager.FindByName("manager") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                user.PasswordHash = Crypto.HashPassword("manager123");
                var checkUser = userManager.Create(user);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, UserRoles.Manager);
                }
            }

            // Create Customer Role
            if (!roleManager.RoleExists(UserRoles.Customer))
            {
                var role = new IdentityRole();
                role.Name = UserRoles.Customer;
                roleManager.Create(role);
            }
        }
    }
}
