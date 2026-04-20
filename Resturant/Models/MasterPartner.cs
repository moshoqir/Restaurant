using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class MasterPartner : BaseEntity
{
    [Display(Name ="Id")]
    public int MasterPartnerId { get; set; }

    [Required]
    [Display(Name ="Partner Name")]
    public string MasterPartnerName { get; set; } = null!;

    [Display(Name ="Partner Logo")]
    public string? MasterPartnerLogoImageUrl { get; set; } = null!;

    [Required]
    [Display(Name ="Partner Website")]
    public string MasterPartnerWebsiteUrl { get; set; } = null!;
}
