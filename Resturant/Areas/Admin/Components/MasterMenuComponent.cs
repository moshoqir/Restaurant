using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Components
{
    public class MasterMenuComponent : ViewComponent
    {
     
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuComponent(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }


        public IViewComponentResult Invoke()
        {
            var data = MasterMenu.ViewAdmin();
            return View(data);
        }
    }
}
