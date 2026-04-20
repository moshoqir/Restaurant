using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuController(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }


        public IActionResult Index(int DeleteId)
        {
            var data = MasterMenu.ViewAdmin();

           

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Required Data!");

                    return View(collection);
                }

                MasterMenu.Add(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
           
        }


  

        public ActionResult Delete(int id)
        {
            try
            {
                MasterMenu.Delete(id, new Models.MasterMenu());

                return RedirectToAction(nameof(Index));
            }
            catch
            { 
                return View();
            }
        }


        public ActionResult Active(int id)
        {
            try
            {
                MasterMenu.Active(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterMenu record = MasterMenu.Find(id);

            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                MasterMenu.Update(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
