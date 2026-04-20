using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant.Models;

namespace Resturant.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }




        // Categories table
        public  DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; }

        // Menu (products) table FK from Categories
        public  DbSet<MasterItemMenu> MasterItemMenus { get; set; }

        // MasterMenus table
        public  DbSet<MasterMenu> MasterMenus { get; set; }

        public  DbSet<MasterOffer> MasterOffers { get; set; }

        public  DbSet<MasterPartner> MasterPartners { get; set; }

        public  DbSet<MasterService> MasterServices { get; set; }

        public  DbSet<MasterSlider> MasterSliders { get; set; }

        public  DbSet<MasterSocialMedia> MasterSocialMedia { get; set; }

        public  DbSet<MasterWorkingHour> MasterWorkingHours { get; set; }

        public  DbSet<SystemSetting> SystemSettings { get; set; }

        public  DbSet<TransactionBookTable> TransactionBookTables { get; set; }

        public  DbSet<TransactionContactUs> TransactionContactUs { get; set; }

        public  DbSet<TransactionNewsletter> TransactionNewsletters { get; set; }

        public DbSet<MasterFeedback> MasterFeedbacks { get; set; }
    }
}
