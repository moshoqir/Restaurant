using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterSlider : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterSliderId { get; set; }

    [Required]
    [Display(Name ="Slider Title")]
    public string MasterSliderTitle { get; set; } = null!;
    [Required]
    [Display(Name ="Slider Breef")]
    public string MasterSliderBreef { get; set; } = null!;
    [Required]
    [Display(Name ="Slider Description")]
    public string MasterSliderDesc { get; set; } = null!;
 
    [Display(Name ="Slider Image")]
    public string? MasterSliderImageUrl { get; set; } = null!;
}
