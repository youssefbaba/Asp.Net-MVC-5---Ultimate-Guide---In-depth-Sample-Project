using DataLayer;
using DomainModels;
using EFCodeFirstApproachExample.Filters;
using ServiceContracts;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EFCodeFirstApproachExample.Controllers
{
    [CustomerAuthorizationFilter]
    public class ProductsController : Controller
    {
        private CompanyDbContext _db;
        private IProductsService _productsService;
         
        public ProductsController()
        {
            _db = new CompanyDbContext();
            _productsService = new ProductsService();
        }

        [HttpGet]
        // GET: /Products/Index
        public ActionResult Index(int currentPage = 1)
        {
            //throw new Exception("Some Exception For Testing Purpose");
            List<Product> products;
            products = _productsService.GetProducts();

            // Pagination
            var numberOfItemsPerPage = 4;
            var numberOfPages = Convert.ToInt32((Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(numberOfItemsPerPage))));
            ViewBag.currentPage = currentPage;
            ViewBag.numberOfPages = numberOfPages;
            products = _productsService.SkipAndTakeProducts(products, (currentPage - 1) * numberOfItemsPerPage, numberOfItemsPerPage);
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Product product)
        {
            return PartialView("DisplayProduct", product);
        }

        [HttpGet]
        [Route("Products/Details/{productId:long}")]
        // GET: /Products/Details/1
        public ActionResult Details(long productId)
        {
            Product product = _productsService.GetProductByProductId(productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}