using System.ComponentModel.DataAnnotations;

namespace Resturant.Areas.Admin.ViewModels
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
