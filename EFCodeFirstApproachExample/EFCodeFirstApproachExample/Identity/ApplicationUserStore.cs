using Microsoft.AspNet.Identity.EntityFramework;

namespace EFCodeFirstApproachExample.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}