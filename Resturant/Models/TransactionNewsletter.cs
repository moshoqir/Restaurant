using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class TransactionNewsletter : TransBaseEntity
{
    public int TransactionNewsletterId { get; set; }

    [Required]
    [EmailAddress]
    public string TransactionNewsletterEmail { get; set; } = null!;
}
