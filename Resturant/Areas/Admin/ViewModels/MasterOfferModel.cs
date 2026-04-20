using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace Resturant.Areas.Admin.ViewModels
{
    public class MasterOfferModel : BaseEntity
    {
        public int MasterOfferId { get; set; }

        [Required]
        [Display(Name = "Offer Title")]
        public string MasterOfferTitle { get; set; } = null!;
        [Required]
        [Display(Name = "Offer Breef")]
        public string MasterOfferBreef { get; set; } = null!;
        [Required]
        [Display(Name = "Offer Description")]
        public string MasterOfferDesc { get; set; } = null!;
       
        [Display(Name = "Offer Image")]
        public string? MasterOfferImageUrl { get; set; } = null!;

        public IFormFile? File { get; set; } = null!;
    }
}
