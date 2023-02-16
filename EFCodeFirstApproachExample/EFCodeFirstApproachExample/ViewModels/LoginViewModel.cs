using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstApproachExample.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name can't be blank")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; }
    }
}