using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IWebHostEnvironment Host { get; }
        public MasterSocialMediaController(IRepository<MasterSocialMedia> _MasterSocialMedia, 
            IWebHostEnvironment _Host)
        {
            MasterSocialMedia = _MasterSocialMedia;
            Host = _Host;
        }

       

        public IActionResult Index()
        {
            var data = MasterSocialMedia.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Invalid data!");
                    return View(collection);
                }
                string ImageName = UploadImage(collection.File, collection.MasterSocialMediaId);

                // mapper btwn MV and M
                var socialMediaMapper = new MasterSocialMedia
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaImageUrl = ImageName,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                };

                MasterSocialMedia.Add(socialMediaMapper);

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
                MasterSocialMedia.Active(id);

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
                MasterSocialMedia.Delete(id, new Models.MasterSocialMedia());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterSocialMedia record = MasterSocialMedia.Find(id);


            // mapper
            var socialMediaMapper = new MasterSocialMediaModel
            {
                MasterSocialMediaId  = record.MasterSocialMediaId,
                 MasterSocialMediaImageUrl = record.MasterSocialMediaImageUrl,
                 MasterSocialMediaUrl = record.MasterSocialMediaUrl,
                 
                IsActive = record.IsActive,
            };

            return View(socialMediaMapper);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaModel collection)
        {
            try
            {
                string ImageName = collection.File != null ?
                    UploadImage(collection.File, collection.MasterSocialMediaId ) : collection.MasterSocialMediaImageUrl ;

                // mapper 
                var socialMediaMapper = new MasterSocialMedia
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,

                    IsActive = collection.IsActive,
                };

                MasterSocialMedia.Update(id, socialMediaMapper);

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
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "socialmedia");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image -" + id + "- SocialMedia" + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file info to full path
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return ImageName;
        }
    }
}
