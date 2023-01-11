using CarRental.Library.Entity;
using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class MobileHeader : ViewComponent
    {
        private readonly ISettingService _settingService;

        public MobileHeader(
            ISettingService settingService)
        {
            _settingService = settingService;
        }
        public IViewComponentResult Invoke()
        {
            MobileHeaderHeaderDto model = new MobileHeaderHeaderDto()
            {
                SiteSetting = _settingService.Get()
            };
            return View(model);
        }
    }
    public class MobileHeaderHeaderDto
    {
        public Setting SiteSetting { get; set; } = new Setting();
    }
}
