using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IWebHostEnvironment Host { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu,
            IWebHostEnvironment _Host, IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterItemMenu = _MasterItemMenu;
            Host = _Host;
            MasterCategoryMenu = _MasterCategoryMenu;
        }

        

        public IActionResult Index()
        {
            var data = MasterItemMenu.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            // send data to view 
            ViewBag.categoryList = MasterCategoryMenu.ViewAdmin();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            ViewBag.categoryList = MasterCategoryMenu.ViewAdmin();
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "Invalid data!");

                return View(collection);
            }

            try
            {
                string ImageName = UploadImage(collection.File, collection.MasterCategoryMenuId);

                // mapper btwn VM and M
                var itemMenuMapper = new MasterItemMenu
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
               
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl  = ImageName,
                   MasterItemMenuDate = collection.MasterItemMenuDate,

                };

                MasterItemMenu.Add(itemMenuMapper);

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
                MasterItemMenu.Active(id);
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
                MasterItemMenu.Delete(id, new Models.MasterItemMenu());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterItemMenu record = MasterItemMenu.Find(id);

            // mapper
            var itemMenuMapper = new MasterItemMenuModel
            {
                MasterItemMenuId = record.MasterItemMenuId,
                MasterCategoryMenuId = record.MasterCategoryMenuId,
                MasterItemMenuTitle = record.MasterItemMenuTitle,
                MasterItemMenuBreef = record.MasterItemMenuBreef,
                MasterItemMenuDesc = record.MasterItemMenuDesc,
                MasterItemMenuPrice = record.MasterItemMenuPrice,
                MasterItemMenuImageUrl = record.MasterItemMenuImageUrl,
                MasterItemMenuDate = (DateTime)record.MasterItemMenuDate,
                IsActive = record.IsActive,

            };
            ViewBag.categoryList = MasterCategoryMenu.ViewAdmin();
            return View(itemMenuMapper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            try
            {
                ViewBag.categoryList = MasterCategoryMenu.ViewAdmin();

                string ImageName = collection.File != null ?
                    UploadImage(collection.File, collection.MasterItemMenuId) : collection.MasterItemMenuImageUrl;

                // mapper
                var itemMenuMapper = new MasterItemMenu
                {
                    MasterItemMenuId =  collection.MasterItemMenuId,
                    MasterCategoryMenuId =collection.MasterCategoryMenuId,

                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = ImageName,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    IsActive = collection.IsActive,
                };

                MasterItemMenu.Update(id, itemMenuMapper);

                return RedirectToAction(nameof(Index));
            }

            catch 
            {
                return View();
            }

        }



        string UploadImage(IFormFile File, int id)
        {
            string ImageName = "";

            if (File != null)
            {
                // get image path
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "items");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image-" + id + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file to full path
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return ImageName;
        }
    }
}
