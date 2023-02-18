using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();

        List<Product> SearchProductsByProductName(string productName);

        List<Product> SkipAndTakeProducts(List<Product> products, int skip, int take);

        Product GetProductByProductId(long productId);

        void InsertProduct(Product product);

        Product UpdateProduct(Product product);

        Product DeleteProduct(long productId);
    }
}
