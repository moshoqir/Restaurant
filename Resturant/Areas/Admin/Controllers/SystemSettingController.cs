using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public IWebHostEnvironment Host { get; }
        public SystemSettingController(IRepository<SystemSetting> _SystemSetting,
            IWebHostEnvironment _Host)
        {
            SystemSetting = _SystemSetting;
            Host = _Host;
        }



        public IActionResult FullAction(int? id)
        {
            // to handle what to return in VM (with data or empty)
            SystemSettingModel VModel;

            // if there is no value or id = 0, always assign the first value from table
            if (!id.HasValue || id == 0)
            {
                var firstRecord = SystemSetting.ViewAdmin().FirstOrDefault();

                // if there is record, assign the id for it
                if (firstRecord != null)
                {
                    id = firstRecord.SystemSettingId;
                }
            }

            // if id actually HasValue, then find the record(id) of it and start mapping from VM

            if (id.HasValue && id > 0)
            {
                SystemSetting record = SystemSetting.Find(id.Value);

                // hadle null ref first
                if (record == null)
                {
                    return View();
                }

                // mapper Btwn VM we already built (model) and the Model (record)

                VModel = new SystemSettingModel
                {
                    SystemSettingId = record.SystemSettingId,
                    SystemSettingLogoImageUrl = record.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = record.SystemSettingLogoImageUrl2,
                    SystemSettingPhone = record.SystemSettingPhone,
                    SystemSettingEmail = record.SystemSettingEmail,
                    SystemSettingCopyright = record.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = record.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = record.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc  = record.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = record.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = record.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingLocationDetails = record.SystemSettingLocationDetails,
                    SystemSettingMapLocation = record.SystemSettingMapLocation,
                    MapInfo = record.MapInfo,
                    SystemSettingFeedbackDesc = record.SystemSettingFeedbackDesc,
                    SystemSettingItemMenuDesc = record.SystemSettingItemMenuDesc,
                    SystemSettingServiceDesc = record.SystemSettingServiceDesc,
                    TransactionBookTableDesc = record.TransactionBookTableDesc,
                    IsActive = record.IsActive,
                };


            }

            // if there's no record, return new VM 
            else
            {
                VModel = new SystemSettingModel();
            }

            return View(VModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FullAction(SystemSettingModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Ivalid data!");

                    return View(collection);
                }

                // handle all imgs
                string SystemSettingLogoImageUrl = collection.LogoImageUrl != null ?
                    UploadImage(collection.LogoImageUrl) : collection.SystemSettingLogoImageUrl;

                string SystemSettingLogoImageUrl2 = collection.LogoImageUrl2 != null ?
                    UploadImage(collection.LogoImageUrl2) : collection.SystemSettingLogoImageUrl2;

                string SystemSettingWelcomeNoteImageUrl = collection.WelcomeNoteImageUrl != null ?
                    UploadImage(collection.WelcomeNoteImageUrl) : collection.SystemSettingWelcomeNoteImageUrl;

                // end handling imgs


                // Mapper
                var systemSettingMapper = new SystemSetting
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = SystemSettingLogoImageUrl2,
                    SystemSettingPhone = collection.SystemSettingPhone,
                    SystemSettingEmail = collection.SystemSettingEmail,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = SystemSettingWelcomeNoteImageUrl,
                    SystemSettingLocationDetails = collection.SystemSettingLocationDetails,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    MapInfo = collection.MapInfo,
                    SystemSettingFeedbackDesc = collection.SystemSettingFeedbackDesc,
                    SystemSettingItemMenuDesc = collection.SystemSettingItemMenuDesc,
                    SystemSettingServiceDesc = collection.SystemSettingServiceDesc,
                    TransactionBookTableDesc = collection.TransactionBookTableDesc,
                    IsActive = collection.IsActive,
                };

                // handle Edit Vs. Create & check id
                int curentId = 0;
                if (collection.SystemSettingId > 0)
                {
                    SystemSetting.Update(collection.SystemSettingId, systemSettingMapper);
                    
                }

                else
                {
                    SystemSetting.Add(systemSettingMapper);
                    
                }
                return RedirectToAction(nameof(FullAction));

            }
            catch
            {
                return View();
            }
        }


        string UploadImage(IFormFile File)
        {
            string ImageName = "";

            if (File != null)
            {
                // get img path wwwroot
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "systemsetting");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image" + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file to full apth
                File.CopyTo(new FileStream(FullPath, FileMode.Create));

            }

            return ImageName;
        }
    }
}
