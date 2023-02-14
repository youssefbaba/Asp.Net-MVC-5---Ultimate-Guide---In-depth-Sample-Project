using System.Collections.Generic;

namespace EFCodeFirstApproachExample.Models
{
    public class CategoriesBrandsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}