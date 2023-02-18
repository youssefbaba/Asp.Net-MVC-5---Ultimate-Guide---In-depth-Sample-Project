using DomainModels;
using RepositoryContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)  // Dependency Injection
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetProducts()
        {
            return _productsRepository.GetProducts();
        }

        public List<Product> SearchProductsByProductName(string productName)
        {
            return _productsRepository.SearchProductsByProductName(productName);
        }

        public List<Product> SkipAndTakeProducts(List<Product> products, int skip, int take)
        {
            return _productsRepository.SkipAndTakeProducts(products, skip, take);
        }

        public Product GetProductByProductId(long productId)
        {
            return _productsRepository.GetProductByProductId(productId);
        }

        public void InsertProduct(Product product)
        {
            if (product.Price <= 100000)
            {
                _productsRepository.InsertProduct(product);
            }
            else
            {
                throw new Exception("Price Exeeds The Limit");
            }
        }
        public Product UpdateProduct(Product product)
        {
            return _productsRepository.UpdateProduct(product);
        }

        public Product DeleteProduct(long productId)
        {
            return _productsRepository.DeleteProduct(productId);
        }
    }
}
