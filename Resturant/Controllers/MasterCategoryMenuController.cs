using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Controllers
{
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterCategoryMenu = _MasterCategoryMenu;
        }

        public IActionResult Index()
        {
            
            return View();
        }



        [HttpPost]
        
        public IActionResult Active(int ElementId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            

            return RedirectToAction("Index");
        }
    }
}
