using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUs { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> _TransactionContactUs)
        {
            TransactionContactUs = _TransactionContactUs;
        }


        public IActionResult Index()
        {
            var data = TransactionContactUs.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Prefix = "TransactionContactUs")] TransactionContactUs collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(
                            x => x.Key,
                            x => x.Value.Errors.Select(e =>
                                string.IsNullOrWhiteSpace(e.ErrorMessage) ? e.Exception?.Message : e.ErrorMessage
                            ).ToList()
                        );

                    TempData["BookingErrors"] = System.Text.Json.JsonSerializer.Serialize(errors);
                    return RedirectToAction("Index", "ContactUs", new { area = "" });
                }

                TransactionContactUs.Add(collection);
                TempData["BookingSuccess"] = "Feedback sent!";
                return RedirectToAction("Index", "ContactUs", new { area = "" });
            }

            catch
            {
                return View();
            }
        }
    }
}
