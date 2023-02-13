using EFDbFirstApproachExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EFDbFirstApproachExample.Controllers
{
    public class BrandsController : Controller
    {
        private EFDBFirstDatabaseEntities _db;

        public BrandsController()
        {
            _db = new EFDBFirstDatabaseEntities();
        }

        [HttpGet]
        // GET: /Brands/Index
        public ActionResult Index()
        {
            List<Brand> brands = _db.Brands.ToList();
            return View(brands);
        }
    }
}