using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterMenu : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterMenuId { get; set; }

    [Required]
    [Display(Name ="Name")]
    public string MasterMenuName { get; set; } = null!;

    [Required]
    [Display(Name ="Url")]
    public string MasterMenuUrl { get; set; } = null!;

   
}
