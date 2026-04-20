using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterSocialMedia : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterSocialMediaId { get; set; }
    
    [Display(Name ="Social Media Image")]
    public string? MasterSocialMediaImageUrl { get; set; } = null!;

    [Required]
    [Display(Name ="Social Media Url")]
    public string MasterSocialMediaUrl { get; set; } = null!;
}
