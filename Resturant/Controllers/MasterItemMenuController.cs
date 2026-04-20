using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;
using Resturant.ViewModel;

namespace Resturant.Controllers
{
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu,
            IRepository<MasterMenu> _MasterMenu, IRepository<SystemSetting> _SystemSetting,
            IRepository<MasterCategoryMenu> _MasterCategoryMenu,
            IRepository<MasterPartner> _MasterPartner,
            IRepository<MasterSocialMedia> _MasterSocialMedia,
            IRepository<MasterWorkingHour> _MasterWorkingHour,
            IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            MasterItemMenu = _MasterItemMenu;
            MasterMenu = _MasterMenu;
            SystemSetting = _SystemSetting;
            MasterCategoryMenu = _MasterCategoryMenu;
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
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                ListMasterItemMenu = MasterItemMenu.ViewClient(),
                ListMasterCategoryMenu = MasterCategoryMenu.ViewClient(),
                ListMasterPartner = MasterPartner.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHour.ViewClient(),
            };
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = new DataModel
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                
                MasterItemMenu = MasterItemMenu.ViewClient()
                .FirstOrDefault(x => x.MasterItemMenuId == id),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHour.ViewClient(),


            };
          

            return View( data );
        }
    }
}
