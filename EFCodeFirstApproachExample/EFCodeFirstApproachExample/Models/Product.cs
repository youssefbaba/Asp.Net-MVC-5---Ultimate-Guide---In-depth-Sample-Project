using EFCodeFirstApproachExample.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstApproachExample.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Product Name can't be blank")]
        [RegularExpression(@"^[0-9A-Za-z ]*$", ErrorMessage = "Product Name should contain only alphabetics and numbers")]
        [MaxLength(20, ErrorMessage = "Product Name can be maximum 20 characters")]
        [MinLength(2, ErrorMessage = "Product Name should contain at least 2 characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
        [Range(0, 100000, ErrorMessage = "Price should be between 0 and 100000")]
        [PriceDivisibleBy10(ErrorMessage = "Price should be divisible by 10")]
        public decimal? Price { get; set; }

        [Column("DOP", TypeName = "datetime")]
        [Display(Name = "Date Of Purchase")]
        public DateTime? DOP { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Required(ErrorMessage = "Category can't be blank")]
        [Display(Name = "Category")]
        public long? CategoryID { get; set; }

        [Required(ErrorMessage = "Brand can't be blank")]
        [Display(Name = "Brand")]
        public long? BrandID { get; set; }

        public bool? Active { get; set; }

        public string Photo { get; set; }

        public string PhotoName { get; set; }

        public decimal? Quantity { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }
    }
}