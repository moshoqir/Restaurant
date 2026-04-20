using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IWebHostEnvironment Host { get; }
        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner, IWebHostEnvironment _Host)
        {
            MasterPartner = _MasterPartner;
            Host = _Host;
        }

       

        public IActionResult Index()
        {
            var data = MasterPartner.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
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
                 

                string ImageName = UploadImage(collection.File, collection.MasterPartnerId);

                // mapper btwn MV and M
                var partnerMapper = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                };

                MasterPartner.Add(partnerMapper);

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
                MasterPartner.Active(id);

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
                MasterPartner.Delete(id, new Models.MasterPartner());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterPartner record = MasterPartner.Find(id);

            // mapper 
           var partnerMapper = new MasterPartnerModel
            {
                MasterPartnerId = record.MasterPartnerId,
                MasterPartnerName = record.MasterPartnerName,
                MasterPartnerLogoImageUrl = record.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = record.MasterPartnerWebsiteUrl,
                IsActive = record.IsActive
            };
            return View(partnerMapper);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                string ImageName = collection.File != null ?
                    UploadImage(collection.File, id) : collection.MasterPartnerLogoImageUrl;

                // mapper 
                var partnerMapper = new MasterPartner 
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    IsActive = collection.IsActive,
                };
                MasterPartner.Update(id, partnerMapper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        string UploadImage(IFormFile File , int id)
        {
            string ImageName = "";

            if (File != null)
            {
                // get img path wwwroot
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "partners");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make uniqe name
                ImageName = "Image -" + id + "- partner" + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file data to full path
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return ImageName;
        }
    }
}
