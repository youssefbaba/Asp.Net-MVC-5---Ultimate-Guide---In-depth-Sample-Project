using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Category
    {
        [Key]
        public long CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}