using EFDbFirstApproachExample.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EFDbFirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        private EFDBFirstDatabaseEntities _db;

        public ProductsController()
        {
            _db = new EFDBFirstDatabaseEntities();
        }

        [HttpGet]
        // GET: /Products/Index
        public ActionResult Index(string keyWord = "", string criteria = "ProductName", string order = "asc")
        {
            ViewBag.keyWord = keyWord;
            List<Product> products;
            products = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.ProductName.Contains(keyWord))
                .ToList();

            // Sorting
            ViewBag.criteria = criteria;
            ViewBag.order = order;
            switch (criteria)
            {
                case "ProductID":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.ProductID).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.ProductID).ToList();
                    }
                    break;
                case "ProductName":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.ProductName).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.ProductName).ToList();
                    }
                    break;
                case "Price":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.Price).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Price).ToList();
                    }
                    break;
                case "DateOfPurchase":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.DateOfPurchase).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.DateOfPurchase).ToList();
                    }
                    break;
                case "AvailabilityStatus":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.AvailabilityStatus).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.AvailabilityStatus).ToList();
                    }
                    break;
                case "Category":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.Category.CategoryName).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Category.CategoryName).ToList();
                    }
                    break;
                case "Brand":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.Brand.BrandName).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Brand.BrandName).ToList();
                    }
                    break;
                case "Active":
                    if (order == "asc")
                    {
                        products = products.OrderBy(p => p.Active).ToList();
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Active).ToList();
                    }
                    break;
            }
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

        [HttpGet]
        // GET: /Products/Create
        public ActionResult Create()
        {
            var viewModel = new CategoriesBrandsViewModel()
            {
                Product = new Product(),
                Categories = _db.Categories.ToList(),
                Brands = _db.Brands.ToList()
            };
            return View(viewModel);
        }

        [HttpGet]
        [Route("Products/Edit/{productId:long}")]
        public ActionResult Edit(long productId)
        {
            Product product = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .SingleOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoriesBrandsViewModel()
            {
                Product = product,
                Categories = _db.Categories.ToList(),
                Brands = _db.Brands.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        // POST:
        public ActionResult Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _db.Products.Add(product);
            }
            else
            {
                Product productInDb = _db.Products.SingleOrDefault(p => p.ProductID == product.ProductID);
                if (product == null)
                {
                    return HttpNotFound();
                }
                productInDb.ProductName = product.ProductName;
                productInDb.Price = product.Price;
                productInDb.DateOfPurchase = product.DateOfPurchase;
                productInDb.AvailabilityStatus = product.AvailabilityStatus;
                productInDb.CategoryID = product.CategoryID;
                productInDb.BrandID = product.BrandID;
                productInDb.Active = product.Active;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(long productId)
        {
            Product product = _db.Products.SingleOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}