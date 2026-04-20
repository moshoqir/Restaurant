using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public IWebHostEnvironment Host { get; }

        public AccountController(UserManager<ApplicationUser> _UserManager,
            SignInManager<ApplicationUser> _SignInManager,
            IWebHostEnvironment _Host)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            Host = _Host;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(kvp => kvp.Value.Errors.Count > 0)
                        .Select(kvp => new
                        {
                            Field = kvp.Key,
                            Errors = kvp.Value.Errors.Select(e =>
                                string.IsNullOrWhiteSpace(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage
                            ).ToList()
                        })
                        .ToList();

                    ViewBag.ModelErrors = errors; // send to view
                    return View(collection);
                }


                string ImageName = "";

                if (collection.File != null)
                {
                    // get img path
                    string ImagePath = Path.Combine(Host.WebRootPath, "images", "users");

                    // get file info
                    FileInfo file = new FileInfo(collection.File.FileName);

                    // create unique name
                    ImageName = "User_" + Guid.NewGuid() + file.Extension;

                    // get full path
                    string FullPath = Path.Combine(ImagePath, ImageName);

                    // save img
                    collection.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }

                var user = new ApplicationUser
                {
                    Email = collection.Email,
                    UserName = collection.UserName,
                    // image
                    Image  = ImageName
                    

                    //PasswordHash = collection.Password
                };

                var Result = await UserManager.CreateAsync(user, collection.Password);

                if (Result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");

            }
            catch
            {
                return View();
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Login(LoginModel collection)
        {
            try
            {
               

                var user = await UserManager.FindByEmailAsync(collection.Email);

                if (!ModelState.IsValid || user == null)
                {
                    ModelState.AddModelError("", "Invalid credentials!");
                    return View(collection);
                }
                var userData = await SignInManager.PasswordSignInAsync
                    (user.UserName,
                    collection.Password,
                    isPersistent: collection.RememberMe,
                    false);

                if (userData.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction(nameof(Login));

            }
            catch
            {
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
