using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstApproachExample.Models
{
    public class Brand
    {
        [Key]
        public long BrandID { get; set; }

        public string BrandName { get; set; }
    }
}