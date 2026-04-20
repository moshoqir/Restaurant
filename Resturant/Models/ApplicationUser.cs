using Microsoft.AspNetCore.Identity;

namespace Resturant.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string? Image { get; set; }
    }
}
