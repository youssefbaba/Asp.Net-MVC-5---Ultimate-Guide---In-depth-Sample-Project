using EFCodeFirstApproachExample.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirstApproachExample.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public List<ApplicationUser> users  { get; set; }
        public List<List<string>> roles  { get; set; }
    }
}