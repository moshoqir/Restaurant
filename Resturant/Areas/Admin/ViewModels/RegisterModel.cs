using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Resturant.Areas.Admin.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(
    @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
    ErrorMessage = "Password must be at least 8 chars and include uppercase, lowercase, a number, and a symbol."
)]

        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password mismatch!")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

        public IFormFile? File { get; set; } 
    }
}
