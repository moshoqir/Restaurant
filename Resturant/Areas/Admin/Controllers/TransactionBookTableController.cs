using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTableRepository { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTableRepository)
        {
            TransactionBookTableRepository = _TransactionBookTableRepository;
        }


        public IActionResult Index()
        {
            var data = TransactionBookTableRepository.ViewAdmin();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(Prefix = "TransactionBookTable")] TransactionBookTable collection)
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
                return Redirect(Url.Action("Index", "Home", new { area = "" }) + "#book");
            }

            TransactionBookTableRepository.Add(collection);
            TempData["BookingSuccess"] = "Reservation sent!";
            return Redirect(Url.Action("Index", "Home", new { area = "" }) + "#book");
        }

    }
}
