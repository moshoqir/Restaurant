using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterCategoryMenu : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterCategoryMenuId { get; set; }
    [Required]
    [Display(Name ="Category Name")]
    public string MasterCategoryMenuName { get; set; } = null!;

  

    public  ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
}
