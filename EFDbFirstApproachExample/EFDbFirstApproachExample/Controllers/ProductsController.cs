using EFDbFirstApproachExample.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ActionResult Index()
        {
            //List<Product> products = _db.Products.ToList();
            //List<Product> products = _db.Products.Where(p => p.CategoryID == 1 && p.Price >= 50000).ToList();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@BrandID", 1)
                //you can add more parameters here
            };
            List<Product> products = _db.Database.SqlQuery<Product>("getProductsByBrandID @BrandID", sqlParameters).ToList();
            return View(products);
        }
    }
}