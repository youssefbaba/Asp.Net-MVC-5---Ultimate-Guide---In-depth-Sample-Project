using DataLayer;
using DomainModels;
using EFCodeFirstApproachExample.Filters;
using ServiceContracts;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorizationFilter]
    public class BrandsController : Controller
    {
        [HttpGet]
        // GET: /Admin/Brands/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}