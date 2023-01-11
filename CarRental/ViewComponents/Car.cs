using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class Car : ViewComponent
    {
        private readonly ICarService _carService;
        public Car(
            ICarService carService)
        {
            _carService = carService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _carService.GetList();
            return View(model);
        }
    }
}
