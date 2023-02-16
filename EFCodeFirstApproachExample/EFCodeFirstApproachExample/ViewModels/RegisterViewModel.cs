using System;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstApproachExample.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User Name can't be blank")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "ConfirmPassword and Password must be the same")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        [Display(Name = "Birth Day")]
        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}