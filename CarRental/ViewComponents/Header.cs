using CarRental.Library.Entity;
using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class Header : ViewComponent
    {
        private readonly ISettingService _settingService;

        public Header(
            ISettingService settingService)
        {
            _settingService = settingService;
        }
        public IViewComponentResult Invoke()
        {
            HeaderDto model = new HeaderDto()
            {
                SiteSetting = _settingService.Get()
            };
            return View(model);
        }
    }
    public class HeaderDto
    {
        public Setting SiteSetting { get; set; } = new Setting();
    }
}
