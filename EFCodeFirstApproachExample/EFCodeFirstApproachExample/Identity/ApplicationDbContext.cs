using Microsoft.AspNet.Identity.EntityFramework;

namespace EFCodeFirstApproachExample.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnectionString")
        {
        }
    }
}