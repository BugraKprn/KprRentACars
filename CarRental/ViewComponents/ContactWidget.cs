
using Microsoft.AspNetCore.Mvc;
using CarRental.Library.Entity;
using CarRental.Library.Services;

namespace CarRental.ViewComponents
{
    public class ContactWidget : ViewComponent
    {
        private readonly ISettingService _service;
        public ContactWidget(
            ISettingService service)
        {
            _service = service;
        }
        public IViewComponentResult Invoke()
        {
            ContactWidgetDto model = new ContactWidgetDto()
            {
                SiteSetting = _service.Get()
            };
            return View(model);
        }
    }

    public class ContactWidgetDto
    {
        public Setting SiteSetting { get; set; } = new Setting();
    }
}
