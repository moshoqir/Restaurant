using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Areas.Admin.ViewModels;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IWebHostEnvironment Host { get; }
        public MasterOfferController(IRepository<MasterOffer> _MasterOffer, IWebHostEnvironment _Host)
        {
            MasterOffer = _MasterOffer;
            Host = _Host;
        }

     

        public IActionResult Index()
        {
            var data = MasterOffer.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
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


                string ImageName = UploadImage(collection.File, collection.MasterOfferId);

                // mapper btwn Vm and M
                var offerMapper = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = ImageName,

                };
                MasterOffer.Add(offerMapper);

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
                MasterOffer.Active(id);

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
                MasterOffer.Delete(id, new Models.MasterOffer());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            MasterOffer record = MasterOffer.Find(id);


            // mapper
            var offerMapper = new MasterOfferModel
            {
                MasterOfferId = record.MasterOfferId,
                MasterOfferTitle = record.MasterOfferTitle,
                MasterOfferBreef = record.MasterOfferBreef,
                MasterOfferDesc = record.MasterOfferDesc,
                MasterOfferImageUrl = record.MasterOfferImageUrl,
                IsActive = record.IsActive,
            };

            return View(offerMapper);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {
                string ImageName = collection.File != null ?
                    UploadImage(collection.File, collection.MasterOfferId) : collection.MasterOfferImageUrl;

                // mapper 
                var offerMapper = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferImageUrl = ImageName,
                    IsActive = collection.IsActive,
                };

                MasterOffer.Update(id, offerMapper);

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
                // get Image path
                string ImagePath = Path.Combine(Host.WebRootPath, "images", "offers");

                // get file info
                FileInfo file = new FileInfo(File.FileName);

                // make unique name
                ImageName = "Image- " + id + "- Offer" + Guid.NewGuid().ToString() + file.Extension;

                // get full path
                string FullPath = Path.Combine(ImagePath, ImageName);

                // copy file to full path
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return ImageName;
        }
    }
}
