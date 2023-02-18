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
        private CompanyDbContext _db;
        private IBrandsService _brandsService;

        public BrandsController()
        {
            _db = new CompanyDbContext();
            _brandsService = new BrandsService();
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