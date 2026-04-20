using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositories;
using Resturant.ViewModel;

namespace Resturant.Controllers
{
    public class ContactUsController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public ContactUsController(IRepository<MasterMenu> _MasterMenu,
            IRepository<TransactionContactUs> _TransactionContactUs,
            IRepository<SystemSetting> _SystemSetting, 
            IRepository<MasterSocialMedia> _MasterSocialMedia,
            IRepository<MasterWorkingHour> _MasterWorkingHour,
            IRepository<TransactionNewsletter> _TransactionNewsletter 
            )
        {
            MasterMenu = _MasterMenu;
            TransactionContactUs = _TransactionContactUs;
            SystemSetting = _SystemSetting;
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
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHour.ViewClient()

            };
            return View(data);
        }
    }
}
