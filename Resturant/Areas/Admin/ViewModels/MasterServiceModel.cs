using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace Resturant.Areas.Admin.ViewModels
{
    public class MasterServiceModel : BaseEntity
    {
        [Display(Name = "Id")]
        public int MasterServiceId { get; set; }



        [Required]
        [Display(Name = "Service Name")]
        public string MasterServiceTitle { get; set; } = null!;
        [Required]
        [Display(Name = "Service Description")]
        public string MasterServiceDesc { get; set; } = null!;


        [Display(Name = "Service Image")]
        public string? MasterServiceImage { get; set; } = null!;


        public IFormFile? File { get; set; } = null!;
    }
}
