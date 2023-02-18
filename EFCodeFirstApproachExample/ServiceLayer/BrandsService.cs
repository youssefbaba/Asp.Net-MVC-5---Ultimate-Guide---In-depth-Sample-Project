using DataLayer;
using DomainModels;
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
        private CompanyDbContext _db;

        public BrandsService()
        {
            _db = new CompanyDbContext();
        }
        public List<Brand> GetBrands()
        {
            return _db.Brands.ToList();
        }
    }
}
