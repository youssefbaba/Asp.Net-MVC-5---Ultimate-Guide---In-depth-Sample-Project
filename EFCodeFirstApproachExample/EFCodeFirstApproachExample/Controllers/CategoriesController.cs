using EFCodeFirstApproachExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    public class CategoriesController : Controller
    {
        private CompanyDbContext _db;

        public CategoriesController()
        {
            _db = new CompanyDbContext();
        }

        [HttpGet]
        // GET: /Categories/Index
        public ActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
    }
}