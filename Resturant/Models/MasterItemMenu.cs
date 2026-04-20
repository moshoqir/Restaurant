using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterItemMenu : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterItemMenuId { get; set; }


    [Required]
    [Display(Name = "Title")]
    public string MasterItemMenuTitle { get; set; } = null!;

    [Required]
    [Display(Name ="Category")]
    public int MasterCategoryMenuId { get; set; }
    
    [Required]
    [Display(Name ="Breef")]
    public string MasterItemMenuBreef { get; set; } = null!;

   

    [Required]
    [Display(Name ="Description")]
    public string MasterItemMenuDesc { get; set; } = null!;
    [Required]
    [Display(Name ="Price")]
    public double MasterItemMenuPrice { get; set; }
  
    [Display(Name = "Image")]
    public string? MasterItemMenuImageUrl { get; set; } = null!;

    [Display(Name ="Date")]
    public DateTime? MasterItemMenuDate { get; set; } = DateTime.Now;
    [Display(Name = "Category")]
    public MasterCategoryMenu? MasterCategoryMenu { get; set; } = null!;
}
