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
        private IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService) // Dependency Injection
        {
            _brandsService = brandsService;
        }

        [HttpGet]
        // GET: /Admin/Brands/Index
        public ActionResult Index()
        {
            List<Brand> brands = _brandsService.GetBrands();    
            return View(brands);
        }
    }
}