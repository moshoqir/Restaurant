using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace Resturant.Areas.Admin.ViewModels 
{
    public class MasterItemMenuModel : BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterItemMenuId { get; set; }


        [Required]
        [Display(Name = "Title")]
        public string MasterItemMenuTitle { get; set; } = null!;

        [Required]
        [Display(Name = "Category")]
        public int MasterCategoryMenuId { get; set; }

        [Required]
        [Display(Name = "Breef")]
        public string MasterItemMenuBreef { get; set; } = null!;

  

        [Required]
        [Display(Name = "Description")]
        public string MasterItemMenuDesc { get; set; } = null!;
        [Required]
        [Display(Name = "Price")]
        public double MasterItemMenuPrice { get; set; }
         
        [Display(Name = "Image")]
        public string? MasterItemMenuImageUrl { get; set; } = null!;

        public DateTime MasterItemMenuDate { get; set; } = DateTime.Now;

        public MasterCategoryMenu? MasterCategoryMenu { get; set; } = null!;

        public IFormFile? File { get; set; }
    }
}
