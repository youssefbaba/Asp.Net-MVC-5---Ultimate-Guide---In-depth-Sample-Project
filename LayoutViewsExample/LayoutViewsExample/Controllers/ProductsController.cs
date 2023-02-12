using LayoutViewsExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        // GET: /products/index
        public ActionResult Index()
        {
            var products = GetProducts();
            return View(products);
        }

        [HttpGet]
        // GET : /products/details/1
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return Content("Please pass any ProductId");
            }
            var products = GetProducts();
            var product = products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpGet]
        // GET : /products/getProductid/Camera
        public ActionResult GetProductId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return Content("Please pass any ProductName");
            }
            var products = GetProducts();
            var product = products.SingleOrDefault(p => p.ProductName == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return Content($"Product Name = {product.ProductName}");
        }

        [NonAction]
        private IEnumerable<Product> GetProducts()
        {

            var products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "Camera", Price = 1500 },
                new Product() { ProductId = 2, ProductName = "Galaxy S10", Price = 1900 },
                new Product() { ProductId = 3, ProductName = "Hp Printer", Price = 1000 },
                new Product() { ProductId = 4, ProductName = "Hp Laptop", Price = 2500 }
            };
            return products;
        }
    }
}