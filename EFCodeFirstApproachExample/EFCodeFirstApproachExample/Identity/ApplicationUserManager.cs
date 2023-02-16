using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EFCodeFirstApproachExample.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(UserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}