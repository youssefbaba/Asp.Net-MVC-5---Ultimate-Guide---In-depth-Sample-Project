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
    public class CategoriesController : Controller
    {
        private CompanyDbContext _db;
        private ICategoriesService _categoriesService;

        public CategoriesController()
        {
            _db = new CompanyDbContext();
            _categoriesService = new CategoriesService();
        }

        [HttpGet]
        // GET: /Admin/Categories/Index
        public ActionResult Index()
        {
            List<Category> categories = _categoriesService.GetCategories(); 
            return View(categories);
        }
    }
}