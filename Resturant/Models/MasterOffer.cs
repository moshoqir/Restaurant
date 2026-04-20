using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterOffer : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterOfferId { get; set; }

    [Required]
    [Display(Name ="Offer Title")]
    public string MasterOfferTitle { get; set; } = null!;
    [Required]
    [Display(Name ="Offer Breef")]
    public string MasterOfferBreef { get; set; } = null!;
    [Required]
    [Display(Name ="Offer Description")]
    public string MasterOfferDesc { get; set; } = null!;
    
    [Display(Name ="Offer Image")]
    public string? MasterOfferImageUrl { get; set; } = null!;
}
