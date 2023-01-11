using CarRental.Library.Entity;
using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class Dashboard : ViewComponent
    {
        private readonly IContactService _contactService;
        private readonly ICarService _carService;
        private readonly ISettingService _settingService;

        public Dashboard(
            ICarService carService,
            IContactService contactService,
            ISettingService settingService)
        {
            _contactService = contactService;
            _carService = carService;
            _settingService = settingService;
        }
        public IViewComponentResult Invoke()
        {
            DashboardDto model = new DashboardDto()
            {
                ContactLink = _contactService.GetList(),
                CarLink = _carService.GetList(),
                SettingLink = _settingService.Get()
            };
            return View(model);
        }
    }
    public class DashboardDto
    {
        public List<Library.Entity.Car> CarLink { get; set; } = new List<Library.Entity.Car>() { };
        public List<Contact> ContactLink { get; set; } = new List<Contact>() { };
        public Setting SettingLink { get; set; } = new Setting();
    }
}
