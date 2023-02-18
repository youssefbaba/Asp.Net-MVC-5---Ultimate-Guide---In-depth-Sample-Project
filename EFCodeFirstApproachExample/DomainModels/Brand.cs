using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Brand
    {
        [Key]
        public long BrandID { get; set; }

        public string BrandName { get; set; }
    }
}
