using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class TransactionContactUs : TransBaseEntity
{
    [Display(Name ="Id")]
    public int TransactionContactUsId { get; set; }

    [Required]
    [Display(Name ="Full Name")]
    public string TransactionContactUsFullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [Display(Name ="Email Address")]
    public string TransactionContactUsEmail { get; set; } = null!;

    [Display(Name ="Subject")]
    public string? TransactionContactUsSubject { get; set; } = null!;

    [Required]
    [Display(Name ="Message")]
    [StringLength(2000,MinimumLength = 5,
        ErrorMessage ="Message must be between {2} and {1} chars.")]
    public string TransactionContactUsMessage { get; set; } = null!;
}
