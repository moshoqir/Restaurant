using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace Resturant.Areas.Admin.ViewModels
{
    public class MasterPartnerModel : BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterPartnerId { get; set; }

        [Required]
        [Display(Name = "Partner Name")]
        public string MasterPartnerName { get; set; } = null!;

        [Display(Name = "Partner Logo")]
        public string? MasterPartnerLogoImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Partner Website")]
        public string MasterPartnerWebsiteUrl { get; set; } = null!;

        public IFormFile? File { get; set; } = null!;
    }
}
