using Resturant.Models;

namespace Resturant.ViewModel
{
    public class DataModel
    {
        public List<MasterMenu> ListMasterMenu { get; set; } = null!;
        public List<MasterSlider> ListMasterSlider { get; set; } = null!;

        public SystemSetting SystemSetting { get; set; } = null!;
        public List<MasterService> ListMasterService { get; set; } = null!;
        public List<MasterItemMenu> ListMasterItemMenu { get; set; } = null!;

        public TransactionBookTable TransactionBookTable { get; set; } = null!;

        public List<MasterFeedback> ListMasterFeedback { get; set; } = null!;

        public MasterOffer MasterOffer { get; set; } = null!;

        public List<MasterPartner> ListMasterPartner { get; set; } = null!;

        public List<MasterCategoryMenu> ListMasterCategoryMenu { get; set; }

        public MasterItemMenu MasterItemMenu { get; set; } = null!;

        public TransactionContactUs TransactionContactUs { get; set; } = null!;

        public List<MasterSocialMedia> ListMasterSocialMedia { get; set; } = null!;
        public List<MasterWorkingHour> ListMasterWorkingHours { get; set; } = null!;

        public TransactionNewsletter TransactionNewsletter { get; set; } = null!;


    }
}
