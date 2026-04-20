using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resturant.Models;

public partial class SystemSetting : BaseEntity
{
    [Display(Name ="Id")]
    public int SystemSettingId { get; set; }

 
    [Display(Name ="Logo 1")]
    public string? SystemSettingLogoImageUrl { get; set; } = null!;
   
    [Display(Name ="Logo 2")]
    public string? SystemSettingLogoImageUrl2 { get; set; } = null!;

    [Required]
    [Display(Name ="Company Mobile Number")]
    public string SystemSettingPhone { get; set; } = null!;

    [Required]
    [EmailAddress]
    [Display(Name = "Company Email Address")]
    public string SystemSettingEmail { get; set; } = null!;

    [Required]
    [Display(Name ="Copyright")]
    public string SystemSettingCopyright { get; set; } = null!;

   

    // For About
    [Required]
    [Display(Name ="Welcome Note Title")]
    public string SystemSettingWelcomeNoteTitle { get; set; } = null!;

    // For About
    [Display(Name = "Welcome Note Breef")]
    public string? SystemSettingWelcomeNoteBreef { get; set; } = null!;

    [Display(Name = "Welcome Note Description")]
    // For About
    public string? SystemSettingWelcomeNoteDesc { get; set; } = null!;

    // For About (About url
    [Display(Name = "About Url")]
    public string? SystemSettingWelcomeNoteUrl { get; set; } = null!;

    // For About
    [Display(Name = "Welcome Note Image")]
    public string? SystemSettingWelcomeNoteImageUrl { get; set; } = null!;

    [Required]
    [Display(Name ="Location Details")]
    public string SystemSettingLocationDetails { get; set; } = null!;

    [Required]
    [Display(Name ="Map Location (iframe)")]
    public string SystemSettingMapLocation { get; set; } = null!;

    [Display(Name ="Map Link")]
    public string MapInfo { get; set; } = null!;

    // For feedback description
    [Required]
    [Display(Name = "Feedback Description")]
 
    public string SystemSettingFeedbackDesc { get; set; } = null!;


    // For item menu description
    [Required]
    [Display(Name = "Menu Description")]

    public string SystemSettingItemMenuDesc { get; set; } = null!;

    // For main outer Services
    [Display(Name = "Services Description")]
    public string SystemSettingServiceDesc { get; set; } = null!;

    // for booking table description
    [Display(Name ="Booking Table Description")]
    public string TransactionBookTableDesc { get; set; } = null!;
}
