using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }


        public IActionResult Index()
        {
            var data = TransactionNewsletter.ViewAdmin();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult Create([Bind(Prefix = "TransactionNewsletter")] TransactionNewsletter collection)
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
                    return Redirect(Url.Action("Index", "Home", new { area = "" }) + "#newsletter");
                }

                TransactionNewsletter.Add(collection);
                TempData["BookingSuccess"] = "Subsecribtion sent!";
                return Redirect(Url.Action("Index", "Home", new {area = ""}) + "#newsletter");
            }
            catch
            {
                return View();
            }
        }


    }
}
