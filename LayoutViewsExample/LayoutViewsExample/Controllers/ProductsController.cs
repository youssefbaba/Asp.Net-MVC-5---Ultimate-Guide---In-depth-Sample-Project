using LayoutViewsExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("Products/Index")]
        // GET: /Products/Index
        public ActionResult Index()
        {
            var products = GetProducts();
            return View(products);
        }

        [HttpGet]
        //[Route("Products/Details/{id:int:range(1,4)}")]  // In This Case id is mandatory
        [Route("Products/Details/{id:int:range(1,4)?}")]  // In This Case id is optional
        // GET : /Products/Details/1
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
        //[Route("Products/GetProductId/{productName:maxlength(50)}")]  // In This Case productName is mandatory
        [Route("Products/GetProductId/{productName:maxlength(50)?}")]  // In This Case productName is optional
        // GET : /Products/GetProductId/Camera
        public ActionResult GetProductId(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return Content("Please pass any ProductName");
            }
            var products = GetProducts();
            var product = products.SingleOrDefault(p => p.ProductName == productName);
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