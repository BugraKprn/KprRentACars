using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class RentaHome : ViewComponent
    {
        private readonly IHomeService _homeService;
        public RentaHome(
            IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _homeService.GetList();
            return View(model);
        }
    }
}
