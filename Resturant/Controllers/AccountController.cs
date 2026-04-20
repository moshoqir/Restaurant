using Microsoft.AspNetCore.Mvc;

namespace Resturant.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl = null)
        => RedirectToAction("Login", "Account", new { area = "Admin", returnUrl });

        public IActionResult Logout()
            => RedirectToAction("Logout", "Account", new { area = "Admin" });
    }
}
