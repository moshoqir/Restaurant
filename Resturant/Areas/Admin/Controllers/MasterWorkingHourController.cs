using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterWorkingHourController : Controller
    {
        public MasterWorkingHourController(IRepository<MasterWorkingHour> _MasterWorkingHour)
        {
            MasterWorkingHour = _MasterWorkingHour;
        }

        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }

        public IActionResult Index()
        {
            var data = MasterWorkingHour.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(MasterWorkingHour collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Invalid data!");
                    return View(collection);
                }

                MasterWorkingHour.Add(collection);
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
                MasterWorkingHour.Active(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public  ActionResult Delete(int id)
        {
            try
            {
                MasterWorkingHour.Delete(id, new Models.MasterWorkingHour());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterWorkingHour record = MasterWorkingHour.Find(id);
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHour collection)
        {
            try
            {
                MasterWorkingHour.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
