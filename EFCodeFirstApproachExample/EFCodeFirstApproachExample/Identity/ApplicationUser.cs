using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EFCodeFirstApproachExample.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}