using DataLayer;
using DomainModels;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class BrandsRepository : IBrandsRepository
    {
        private CompanyDbContext _db;

        public BrandsRepository()
        {
            _db = new CompanyDbContext();
        }
        public List<Brand> GetBrands()
        {
            return _db.Brands.ToList();
        }
    }
}
