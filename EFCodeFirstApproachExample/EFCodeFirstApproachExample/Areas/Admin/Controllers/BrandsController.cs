using EFCodeFirstApproachExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        private CompanyDbContext _db;

        public BrandsController()
        {
            _db = new CompanyDbContext();
        }

        [HttpGet]
        // GET: /Admin/Brands/Index
        public ActionResult Index()
        {
            List<Brand> brands = _db.Brands.ToList();
            return View(brands);
        }
    }
}