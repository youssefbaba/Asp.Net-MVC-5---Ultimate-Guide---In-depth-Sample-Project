using System.Collections.Generic;

namespace EFDbFirstApproachExample.Models
{
    public class CategoriesBrandsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}