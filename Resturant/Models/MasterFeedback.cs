using System.ComponentModel.DataAnnotations;

namespace Resturant.Models
{
    public class MasterFeedback : BaseEntity
    {
        [Display(Name ="Id")]
        public int MasterFeedbackId { get; set; }

       

        [Required]
        [Display(Name ="Full Name")]
        public string MasterFeedbackFullName { get; set; } = null!;

        public string? Image { get; set; }

        [Display(Name ="Type")]
        public string? MasterFeedbackType { get; set; } = null!;

        [Required]
        [Display(Name ="Comment")]
        public string MasterFeedbackComment { get; set; } = String.Empty;
    }
}
