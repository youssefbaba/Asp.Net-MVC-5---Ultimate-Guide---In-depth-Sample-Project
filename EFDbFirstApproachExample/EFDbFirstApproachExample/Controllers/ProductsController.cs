using EFDbFirstApproachExample.Models;
using System.Collections.Generic;
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
        public ActionResult Index(string keyWord = "")
        {
            List<Product> products;
            products = _db.Products.ToList();
            //products = _db.Products.Where(p => p.CategoryID == 1 && p.Price >= 50000).ToList();
            /*
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@BrandID", 1)
                //you can add more parameters here
            };
            products = _db.Database.SqlQuery<Product>("getProductsByBrandID @BrandID", sqlParameters).ToList();
            */
            products = _db.Products.Where(p => p.ProductName.Contains(keyWord)).ToList();
            ViewBag.keyWord = keyWord;
            return View(products);
        }

        [HttpGet]
        [Route("Products/Details/{productId:long}")]
        // GET: /Products/Details/1
        public ActionResult Details(long productId)
        {
            Product product = _db.Products.SingleOrDefault(p => p.ProductID == productId);
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
            Product product = _db.Products.SingleOrDefault(p => p.ProductID == productId);
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
    }
}