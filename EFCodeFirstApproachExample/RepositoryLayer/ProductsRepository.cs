using DataLayer;
using DomainModels;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ProductsRepository : IProductsRepository
    {
        private CompanyDbContext _db;

        public ProductsRepository()
        {
            _db = new CompanyDbContext();
        }

        public List<Product> GetProducts()
        {
            return _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .ToList();
        }

        public List<Product> SearchProductsByProductName(string productName)
        {
            return _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.ProductName.Contains(productName))
                .ToList();
        }

        public List<Product> SkipAndTakeProducts(List<Product> products, int skip, int take)
        {
            return products.Skip(skip).Take(take).ToList();
        }

        public Product GetProductByProductId(long productId)
        {
            return _db.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .SingleOrDefault(p => p.ProductID == productId);
        }

        public void InsertProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }
        public Product UpdateProduct(Product product)
        {
            Product productInDb = GetProductByProductId(product.ProductID);
            if (productInDb == null)
            {
                return null;
            }
            productInDb.ProductName = product.ProductName;
            productInDb.Price = product.Price;
            productInDb.DOP = product.DOP;
            productInDb.AvailabilityStatus = product.AvailabilityStatus;
            productInDb.CategoryID = product.CategoryID;
            productInDb.BrandID = product.BrandID;
            productInDb.Active = product.Active;
            productInDb.PhotoName = product.PhotoName;
            productInDb.Photo = product.Photo;
            _db.SaveChanges();
            return productInDb;
        }

        public Product DeleteProduct(long productId)
        {
            Product productInDb = GetProductByProductId(productId);
            if (productInDb == null)
            {
                return null;
            }
            _db.Products.Remove(productInDb);
            _db.SaveChanges();
            return productInDb;
        }
    }
}
