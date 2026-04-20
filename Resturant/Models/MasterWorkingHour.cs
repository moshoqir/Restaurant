using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterWorkingHour : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterWorkingHourId { get; set; }

    [Required]
    [Display(Name ="Working Day")]
    public string MasterWorkingHourName { get; set; } = null!;

  
    [Display(Name ="Time From")]
    public TimeOnly? MasterWorkingHourTimeFrom { get; set; }

  
    [Display(Name ="Time To")]
    public TimeOnly? MasterWorkingHourTimeTo { get; set; }
    public bool IsClosed { get; set; }


}
