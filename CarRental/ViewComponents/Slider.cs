using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class Slider : ViewComponent
    {
        private readonly ISliderService _sliderService;
        public Slider(
            ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _sliderService.GetList();
            return View(model);
        }
    }
}
