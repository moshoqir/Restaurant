using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;
using Resturant.ViewModel;

namespace Resturant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterFeedback> MasterFeedback { get; }
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public HomeController(IRepository<MasterFeedback> _MasterFeedback,
            IRepository<MasterMenu> _MasterMenu, IRepository<MasterSlider> _MasterSlider,
            IRepository<SystemSetting> _SystemSetting,
            IRepository<MasterService> _MasterService,
            IRepository<MasterItemMenu> _MasterItemMenu,
            IRepository<TransactionBookTable> _TransactionBookTable,
            IRepository<MasterOffer> _MasterOffer,
            IRepository<MasterPartner> _MasterPartner,
            IRepository<MasterSocialMedia> _MasterSocialMedia,
            IRepository<MasterWorkingHour> _MasterWorkingHour,
            IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            MasterFeedback = _MasterFeedback;
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            MasterService = _MasterService;
            MasterItemMenu = _MasterItemMenu;
            TransactionBookTable = _TransactionBookTable;
            MasterOffer = _MasterOffer;
            MasterPartner = _MasterPartner;
            MasterSocialMedia = _MasterSocialMedia;
            MasterWorkingHour = _MasterWorkingHour;
            TransactionNewsletter = _TransactionNewsletter;
        }

        

        public IActionResult Index()
        {
            var data = new DataModel
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterSlider = MasterSlider.ViewClient(),
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                ListMasterItemMenu = MasterItemMenu.ViewClient().OrderByDescending(x => x.MasterItemMenuId)
                .Take(5).ToList(),
                ListMasterFeedback = MasterFeedback.ViewClient().
                OrderByDescending(x => x.MasterFeedbackId).Take(3).ToList(),
                MasterOffer = MasterOffer.ViewClient().
                OrderByDescending(x =>  x.MasterOfferId).FirstOrDefault(),
                ListMasterPartner = MasterPartner.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHour.ViewClient()



            };
          
            return View(data);
        }

        public IActionResult About()
        {
            var data = new DataModel
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                ListMasterService = MasterService.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHour.ViewClient()

            };
            return View(data);
        }


      
    }
}
