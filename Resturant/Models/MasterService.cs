using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterService : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterServiceId { get; set; }



    [Required]
    [Display(Name ="Service Name")]
    public string MasterServiceTitle { get; set; } = null!;
    [Required]
    [Display(Name ="Service Description")]
    public string MasterServiceDesc { get; set; } = null!;
    

    

   
    [Display(Name = "Service Image")]
    public string? MasterServiceImage { get; set; } = null!;
}
