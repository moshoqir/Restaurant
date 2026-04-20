using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterFeedbackController : Controller
    {
      
        public IRepository<MasterFeedback> MasterFeedback { get; }
        public IWebHostEnvironment Host { get; }

        public MasterFeedbackController(IRepository<MasterFeedback> _MasterFeedback, IWebHostEnvironment _Host)
        {
            MasterFeedback = _MasterFeedback;
            Host = _Host;
        }


        public IActionResult Index()
        {
            var data = MasterFeedback.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterFeedbackModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid data!");
                return View(collection);
            }

            try
            {
                var ImageName = UploadImage(collection.File, collection.MasterFeedbackId);

                // mapper btwn Vm and M
                var feedbackMapper = new MasterFeedback
                {
                    MasterFeedbackId = collection.MasterFeedbackId,
                 
                    MasterFeedbackFullName = collection.MasterFeedbackFullName,
                    Image = ImageName,
                    MasterFeedbackType = collection.MasterFeedbackType,
                    MasterFeedbackComment = collection.MasterFeedbackComment,

                };

                MasterFeedback.Add(feedbackMapper);

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
                MasterFeedback.Active(id);
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
                MasterFeedback.Delete(id, new Models.MasterFeedback());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterFeedback record = MasterFeedback.Find(id);

            // mapper 
            var feedbackMapper = new MasterFeedbackModel
            {
                MasterFeedbackId = record.MasterFeedbackId,
                MasterFeedbackFullName = record.MasterFeedbackFullName,
                Image = record.Image,
                MasterFeedbackType = record.MasterFeedbackType,
                MasterFeedbackComment = record.MasterFeedbackComment,
                IsActive = record.IsActive
                
            };
            return View(feedbackMapper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id , MasterFeedbackModel collection)
        {
            try
            {
                string ImageName = collection.File != null ?
                    UploadImage(collection.File, collection.MasterFeedbackId) : collection.Image;

                // mapper
                var feedbackMapper = new MasterFeedback
                {
                    MasterFeedbackId = collection.MasterFeedbackId,
                    MasterFeedbackFullName = collection.MasterFeedbackFullName,
                    Image = ImageName,
                    MasterFeedbackType = collection.MasterFeedbackType,
                    MasterFeedbackComment = collection.MasterFeedbackComment,
                    IsActive = collection.IsActive
                };

                MasterFeedback.Update(id,feedbackMapper);

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
                // get Img path
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "feedback");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image -" + id + "- Feedback" + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file to full path
                File.CopyTo(new FileStream(FullPath,FileMode.Create));
            }

            return ImageName;
        }
    }
}
