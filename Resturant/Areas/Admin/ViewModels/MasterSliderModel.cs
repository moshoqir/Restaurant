using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace Resturant.Areas.Admin.ViewModels
{
    public class MasterSliderModel : BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterSliderId { get; set; }

        [Required]
        [Display(Name = "Slider Title")]
        public string MasterSliderTitle { get; set; } = null!;
        [Required]
        [Display(Name = "Slider Breef")]
        public string MasterSliderBreef { get; set; } = null!;
        [Required]
        [Display(Name = "Slider Description")]
        public string MasterSliderDesc { get; set; } = null!;

        [Display(Name = "Slider Image")]
        public string? MasterSliderImageUrl { get; set; } = null!;

        public IFormFile? File { get; set; }
    }
}
