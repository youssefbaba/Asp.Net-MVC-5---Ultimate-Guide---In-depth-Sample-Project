using EFCodeFirstApproachExample.Filters;
using EFCodeFirstApproachExample.Models;
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

        public ProductsController()
        {
            _db = new CompanyDbContext();
        }

        [HttpGet]
        // GET: /Products/Index
        public ActionResult Index(int currentPage = 1)
        {
            List<Product> products;
            products = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToList();

            // Pagination
            var numberOfItemsPerPage = 4;
            var numberOfPages = Convert.ToInt32((Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(numberOfItemsPerPage))));
            ViewBag.currentPage = currentPage;
            ViewBag.numberOfPages = numberOfPages;
            products = products.Skip((currentPage - 1) * numberOfItemsPerPage).Take(numberOfItemsPerPage).ToList();
            return View(products);
        }

        [HttpGet]
        [Route("Products/Details/{productId:long}")]
        // GET: /Products/Details/1
        public ActionResult Details(long productId)
        {
            Product product = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .SingleOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}