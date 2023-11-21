using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace Laul.Identity.Quickstart.Account
{
    public class RegistrerInputModel
    {
        [Required(ErrorMessage = "Field Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Field Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }

}
