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
    public class CategoriesRepository : ICategoriesRepository
    {
        private CompanyDbContext _db;

        public CategoriesRepository()
        {
            _db = new CompanyDbContext();
        }
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
