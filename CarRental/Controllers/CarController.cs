using CarRental.Library.Entity;
using CarRental.Library.Helpers;
using CarRental.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private ICarService _carService;
        private ICarImageGalleryService _carImageGalleryService;
        private ISettingService _settingService;
        private IQuickLinkService _quickLinkService;
        private IContactService _contactService;
        public CarController(
            ILogger<CarController> logger
            , ICarService carService
            , ICarImageGalleryService carImageGalleryService
            , ISettingService settingService
            , IQuickLinkService quickLinkService
            , IContactService contactService)
        {
            _logger = logger;
            _carService = carService;
            _carImageGalleryService = carImageGalleryService;
            _settingService = settingService;
            _quickLinkService = quickLinkService;
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("language/en")]
        public IActionResult en()
        {
            ViewData["Title"] = "English | Mays Filo Rent a Car";
            var settingModel = _settingService.Get();
            return View(settingModel);
        }

        [Route("language/sa")]
        public IActionResult sa()
        {
            ViewData["Title"] = "عربي | Mays Filo Rent a Car";
            var settingModel = _settingService.Get();
            return View(settingModel);
        }

        [Route("language/ru")]
        public IActionResult ru()
        {
            ViewData["Title"] = "Русский | Mays Filo Rent a Car";
            var settingModel = _settingService.Get();
            return View(settingModel);
        }

        [Route("Car/Details/{title}/{id}")]
        public IActionResult Details(int id)
        {
            DenemeDto model = new DenemeDto()
            {
                CarModel = _carService.GetById(id),
                CarImageModel = _carImageGalleryService.GetList()
            };
            ViewData["Title"] = "Detay - " + model.CarModel.CarName;
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "İletişim";
            var settingModel = _settingService.Get();
            return View(settingModel);
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Hakkımızda";
            var settingModel = _settingService.Get();
            return View(settingModel);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ContactPost(Contact dto)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Fill in the required fields");
                }
                else
                {
                    _contactService.Create(dto);
                    result.Success = true;
                    result.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            //Write your Insert code here;
            return await Task.FromResult(Ok(result));
        }

        public class DenemeDto
        {
            public Car CarModel { get; set; } = new Car();
            public List<CarImageGallery> CarImageModel { get; set; } = new List<CarImageGallery>() { };
        }
    }
}
