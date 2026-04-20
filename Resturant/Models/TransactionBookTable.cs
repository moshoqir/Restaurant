using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class TransactionBookTable : TransBaseEntity
{
    [Display(Name ="Id")]
    public int TransactionBookTableId { get; set; }

    

    [Required]
    [Display(Name ="Full Name")]
    public string TransactionBookTableFullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [Display(Name ="Email Address")]
    public string TransactionBookTableEmail { get; set; } = null!;

    [Required]
    [Phone]
    [Display(Name ="Phone Number")]
    [RegularExpression(@"\d{10}$",ErrorMessage ="Phone Number must contains 10 numbers")]
    public string TransactionBookTableMobileNumber { get; set; } = null!;

    [Required]
    [Display(Name ="Booking Date")]
    public DateTime TransactionBookTableDate { get; set; }
}
