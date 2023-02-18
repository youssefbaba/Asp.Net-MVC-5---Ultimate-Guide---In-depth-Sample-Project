using DataLayer;
using DomainModels;
using RepositoryContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BrandsService : IBrandsService
    {
        private IBrandsRepository _brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository)  // Dependency Injection
        {
            _brandsRepository = brandsRepository;
        }
        public List<Brand> GetBrands()
        {
            return _brandsRepository.GetBrands();   
        }
    }
}
