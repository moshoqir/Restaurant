using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public IWebHostEnvironment Host { get; }
        public MasterServiceController(IRepository<MasterService> _MasterService, 
            IWebHostEnvironment _Host)
        {
            MasterService = _MasterService;
            Host = _Host;
        }

       

        public IActionResult Index()
        {
            var data = MasterService.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel collection)
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



                string ImageName = UploadImage(collection.File, collection.MasterServiceId);

                // mapper btwn MV and M
                var serviceMapper = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceDesc = collection.MasterServiceDesc,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceImage = ImageName,
                };

                MasterService.Add(serviceMapper);
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
                MasterService.Active(id);

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
                MasterService.Delete(id, new Models.MasterService());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterService record = MasterService.Find(id);

            // mapper 
            var serviceMapper = new MasterServiceModel
            {
                MasterServiceId = record.MasterServiceId,
                MasterServiceDesc = record.MasterServiceDesc,
                MasterServiceTitle = record.MasterServiceTitle,
                MasterServiceImage = record.MasterServiceImage,
                IsActive = record.IsActive,
            };
            return View(serviceMapper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id , MasterServiceModel collection)
        {
            try
            {

                string ImageName = collection.File != null ?
                    UploadImage(collection.File, collection.MasterServiceId) : collection.MasterServiceImage;

                // mapper
                var serviceMapper = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceDesc = collection.MasterServiceDesc,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceImage = ImageName,
                    IsActive = collection.IsActive,
                };

                MasterService.Update(id, serviceMapper);
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
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "services");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image -" + id + "- service" + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file data to full path
                File.CopyTo(new FileStream (FullPath,FileMode.Create));
            }

            return ImageName;
        }
    }
}
