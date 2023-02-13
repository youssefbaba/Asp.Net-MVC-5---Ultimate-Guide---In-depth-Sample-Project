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
    }
}