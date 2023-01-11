using CarRental.Library.Helpers;
using CarRental.Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrionDAL.OAL;
using OrionDAL.Web.Entities.Core;

namespace CarRental.Controllers
{
    public class AdminController : Controller
    {
        private ICarImageGalleryService _carImageGalleryService;
        private ICarService _carService;
        private IContactService _contactService;
        private IHomeService _homeService;
        private IQuickLinkService _quickLinkService;
        private IReservationService _reservationService;
        private ISettingService _settingService;
        private ISliderService _sliderService;
        private ISubsNewsletterService _subsNewsletterService;
        private ILogger<AdminController> _logger;

        public AdminController(
            ICarImageGalleryService carImageGalleryService,
            ICarService carService,
            IContactService contactService,
            IHomeService homeService,
            IQuickLinkService quickLinkService,
            IReservationService reservationService,
            ISettingService settingService,
            ISliderService sliderService,
            ISubsNewsletterService subsNewsletterService,
            ILogger<AdminController> logger)
        {
            _carImageGalleryService = carImageGalleryService;
            _carService = carService;
            _contactService = contactService;
            _homeService = homeService;
            _quickLinkService = quickLinkService;
            _reservationService = reservationService;
            _settingService = settingService;
            _sliderService = sliderService;
            _subsNewsletterService = subsNewsletterService;
            _logger = logger;
        }

        [Authorize]
        [Route("admin")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Anasayfa";
            return View();
        }

        [Authorize]
        public IActionResult SettingPage()
        {
            ViewData["Title"] = "Ayarlar";
            return View();
        }

        [Authorize]
        public IActionResult LinkPage()
        {
            ViewData["Title"] = "Hızlı Linkler";
            return View();
        }

        [Authorize]
        public IActionResult ContactPage()
        {
            ViewData["Title"] = "İletişim";
            return View();
        }

        [Authorize]
        public IActionResult SliderPage()
        {
            ViewData["Title"] = "Slider";
            return View();
        }

        [Authorize]
        public IActionResult RentCarPage()
        {
            ViewData["Title"] = "Arabalar";
            return View();
        }

        [Authorize]
        public IActionResult CarImagePage()
        {
            ViewData["Title"] = "Araba Görselleri";
            return View();
        }

        [Route("getsetting")]
        [HttpGet]
        public async Task<IActionResult> GetSetting()
        {
            ApiResult result = new ApiResult();
            try
            {
                result.Data = _settingService.Get();
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

        [Route("getcontact")]
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            ApiResult result = new ApiResult();
            try
            {
                result.Data = _contactService.GetList();
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

        [Route("getquicklinks")]
        [HttpGet]
        public async Task<IActionResult> GetLinks()
        {
            ApiResult result = new ApiResult();
            try
            {
                result.Data = _quickLinkService.GetList();
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

        [Route("getsliders")]
        [HttpGet]
        public async Task<IActionResult> GetSlider()
        {
            ApiResult result = new ApiResult();
            try
            {
                result.Data = _sliderService.GetList();
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

        [Route("getcars")]
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            ApiResult result = new ApiResult();
            try
            {
                result.Data = _carService.GetList();
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

        [Route("getcarsimage")]
        [HttpGet]
        public async Task<IActionResult> GetCarsImage()
        {
            ApiResult result = new ApiResult();
            try
            {
                result.Data = _carImageGalleryService.GetList();
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


        // -------------- //
        // Orion Ayarları //
        // -------------- //



        [HttpPost]
        public string UploadFile(IFormFile myFile)
        {

            var targetLocation = Environment.CurrentDirectory + "/StaticFiles";
            string dosyaUzantisi = Path.GetExtension(myFile.FileName).ToLower();
            Guid g = Guid.NewGuid();


            try
            {
                using (var fileStream = System.IO.File.Create(targetLocation + "/" + g.ToString() + dosyaUzantisi))
                {
                    myFile.CopyTo(fileStream);
                }
            }
            catch
            {
                Response.StatusCode = 400;
            }
            return g.ToString() + dosyaUzantisi;
        }
        [HttpPost]
        public string UploadBigImageFile(IFormFile myBigImageFile)
        {

            var targetLocation = Environment.CurrentDirectory + "/StaticFiles";
            string dosyaUzantisi = Path.GetExtension(myBigImageFile.FileName).ToLower();
            Guid g = Guid.NewGuid();


            try
            {
                using (var fileStream = System.IO.File.Create(targetLocation + "/" + g.ToString() + dosyaUzantisi))
                {
                    myBigImageFile.CopyTo(fileStream);
                }
            }
            catch
            {
                Response.StatusCode = 400;
            }
            return g.ToString() + dosyaUzantisi;
        }
        public JsonResult OrionSave(IFormCollection form)
        {
            var values = form["values"];
            var table = form["tablo"];
            var keyValue = Convert.ToInt32(form["key"]);

            var typeTable = OrionDAL.OAL.Metadata.DataDictionary.Instance.GetTypeofEntity(table);
            var obj = (BaseEntity)(keyValue > 0 ? Transaction.Instance.Read(typeTable, keyValue) : Activator.CreateInstance(typeTable));

            JsonConvert.PopulateObject(values, obj);
            if (table == "Setting" && obj.Id == 0)
            {
                var setting = _settingService.Get();
                if (setting.Id == 0)
                {
                    obj.Save();
                }
                else
                {
                    _logger.LogError("Ayar tablosuna sadece 1 adet kayıt girebilirsiniz.");
                }
            }
            else
            {
                obj.Save();
            }
            return Json(new { data = obj });
        }

        public JsonResult OrionDelete(IFormCollection form)
        {
            var table = form["tablo"];
            var keyValue = Convert.ToInt32(form["key"]);

            var typeTable = OrionDAL.OAL.Metadata.DataDictionary.Instance.GetTypeofEntity(table);
            var obj = (BaseEntity)Transaction.Instance.Read(typeTable, keyValue);
            if (table == "Car")
            {
                _carService.Delete(obj.Id);
            }
            //else if (table == "Ogrenci")
            //{
            //    Transaction.Instance.ExecuteNonQuery("delete from BagisSepeti where OgrenciId=@prm0", obj.Id);
            //    Transaction.Instance.ExecuteNonQuery("delete from BasariliOdemeLog where OgrenciId=@prm0", obj.Id);
            //    Transaction.Instance.ExecuteNonQuery("delete from BasarisizOdemeLog where OgrenciId=@prm0", obj.Id);
            //    Transaction.Instance.ExecuteNonQuery("delete from OdemeAraTablosu where OgrenciId=@prm0", obj.Id);
            //    Transaction.Instance.ExecuteNonQuery("delete from OgrenciBurs where Ogrenci_Id=@prm0", obj.Id);
            //}
            obj.Delete();

            return Json(new { data = "{}" });
        }
    }
}
