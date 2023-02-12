﻿using ModelExample.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ModelExample.Controllers
{
    public class ProductsController : Controller
    {

        [HttpGet]
        // GET: /Products/Index
        public ActionResult Index()
        {
            List<Product> products = GetProducts().ToList();
            return View(products);
        }

        [HttpGet]
        [Route("Products/Details/{productId:int}")]
        // GET: /Products/Details/1
        public ActionResult Details(int productId)
        {
            List<Product> products = GetProducts().ToList();
            var product = products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [NonAction]
        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product{ ProductId = 100, ProductName = "Printer", Rate = 45000 },
                new Product{ ProductId = 101, ProductName = "Mobile", Rate = 38000 },
                new Product{ ProductId = 102, ProductName = "Bike", Rate = 94000 },
            };
        }
    }
}