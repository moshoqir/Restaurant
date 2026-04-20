using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace Resturant.Areas.Admin.ViewModels
{
    public class MasterSocialMediaModel : BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterSocialMediaId { get; set; }

        [Display(Name = "Social Media Image")]
        public string? MasterSocialMediaImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Social Media Url")]
        public string MasterSocialMediaUrl { get; set; } = null!;

        public IFormFile File { get; set; } = null!;
    }
}
