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
        private ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)   // Dependency Injection
        {
            _categoriesService = categoriesService;
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