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
    public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)  // Dependency Injection
        {
            _categoriesRepository = categoriesRepository;
        }
        public List<Category> GetCategories()
        {
            return _categoriesRepository.GetCategories();  
        }
    }
}
