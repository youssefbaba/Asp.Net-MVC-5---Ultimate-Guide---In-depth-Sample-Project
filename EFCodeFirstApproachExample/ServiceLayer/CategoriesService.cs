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
    public class CategoriesService : ICategoriesService
    {
        private CompanyDbContext _db;

        public CategoriesService()
        {
            _db = new CompanyDbContext();
        }
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
