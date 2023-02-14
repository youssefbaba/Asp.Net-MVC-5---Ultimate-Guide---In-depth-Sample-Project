using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstApproachExample.Models
{
    public class Category
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}