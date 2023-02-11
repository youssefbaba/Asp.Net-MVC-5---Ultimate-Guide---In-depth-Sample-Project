using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        // GET: /products/index
        public ActionResult Index()
        {
            var products = new[]
            {
                new { ProductId = 100 , ProductName = "Camera" , Price = 1500},
                new { ProductId = 101 , ProductName = "Galaxy S10" , Price = 1900},
                new { ProductId = 102 , ProductName = "Hp Printer" , Price = 1000},
                new { ProductId = 103 , ProductName = "Hp Laptop" , Price = 2500}
            };
            ViewBag.Products = products;
            return View();
        }
    }
}