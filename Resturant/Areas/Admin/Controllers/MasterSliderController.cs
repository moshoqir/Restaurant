using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public IWebHostEnvironment Host { get; }
        public MasterSliderController(IRepository<MasterSlider> _MasterSlider, IWebHostEnvironment _Host)
        {
            MasterSlider = _MasterSlider;
            Host = _Host;
        }

      

        public IActionResult Index()
        {
            var data = MasterSlider.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Invalid data!");
                }

                string ImageName = UploadImage(collection.File, collection.MasterSliderId);

                // mapper btwn MV and M
                var sliderMapper = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderImageUrl = ImageName,

                };

                MasterSlider.Add(sliderMapper);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public IActionResult Active(int id)
        {
            try
            {
                MasterSlider.Active(id);
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
                MasterSlider.Delete(id, new Models.MasterSlider());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterSlider record = MasterSlider.Find(id);

            // mapper 
           var sliderMapper = new MasterSliderModel
            {
                MasterSliderId = record.MasterSliderId,
                MasterSliderTitle = record.MasterSliderTitle,
                MasterSliderDesc= record.MasterSliderDesc,
                MasterSliderImageUrl = record.MasterSliderImageUrl,
                MasterSliderBreef = record.MasterSliderBreef,
                IsActive = record.IsActive
            };
            return View(sliderMapper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collcetion)
        {
            try
            {
                string ImageName = collcetion.File != null ?
                    UploadImage(collcetion.File, collcetion.MasterSliderId) : collcetion.MasterSliderImageUrl;

                // mapper 
                var sliderMapper = new MasterSlider
                {
                    MasterSliderId = collcetion.MasterSliderId,
                    MasterSliderBreef = collcetion.MasterSliderBreef,
                    MasterSliderDesc = collcetion.MasterSliderDesc,
                    MasterSliderTitle = collcetion.MasterSliderTitle,
                    MasterSliderImageUrl = ImageName,
                    IsActive = collcetion.IsActive
                };

                MasterSlider.Update(id, sliderMapper);
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
                // get image path wwwroot
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "sliders");

                //get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image-" + id + "-slider" + Guid.NewGuid().ToString() + file.Extension;

                //getfull path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copuy file info to  full path
                File.CopyTo(new FileStream(FullPath, FileMode.Create));


            }

            return ImageName;
        }
    }
}
