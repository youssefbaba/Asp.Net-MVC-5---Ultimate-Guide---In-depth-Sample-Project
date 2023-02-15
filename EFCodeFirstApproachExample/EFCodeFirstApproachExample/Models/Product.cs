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
        [MaxLength(50, ErrorMessage = "Product Name must be less than 50 characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
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