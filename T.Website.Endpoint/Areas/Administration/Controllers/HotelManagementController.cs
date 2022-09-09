using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Hotels;
using T.Application.Services.Hotels;
using T.Infrastructure.Messages;
using T.Application.Images;

namespace T.Admin.Endpoint.Controllers;

[Area("Administration")]
public class HotelManagementController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IImageService _imageService;

    public HotelManagementController(IHotelService hotelService, IImageService imageService)
    {
        _hotelService = hotelService;
        _imageService = imageService;
    }

    public IActionResult Index(int page = 1, int pageSize = 100)
    {
        var list = _hotelService.GetList(page, pageSize);
        return View(list);
    }

    public IActionResult Delete(int id)
    {
        var result = _hotelService.Remove(id);
        if (result == false)
            return new JsonResult(new { status = "error" });
        return new JsonResult(new { status = "success" });
    }

    public IActionResult Edit(int id)
    {
        var information = _hotelService.GetInformation();
        var hotel = _hotelService.GetHotel(id);
        var srcs = _hotelService.GetImages(id);
        hotel.ImagesModel = srcs;
        hotel.Information = new InformationDto
        {
            Amenities = information.Amenities,
            CountriesCode = information.CountriesCode,
            CountriesName = information.CountriesName,
            Currencies = information.Currencies,
        };
        return View(hotel);
    }

    [HttpPost]
    public IActionResult Edit(EditDto model)
    {
        if (!ModelState.IsValid)
            return new JsonResult(new { status = "error", message = ResponseMessage.ModelNotValid });
        var imagesSrc = new List<string>();
        if (model.Images != null && model.Images.Count > 0)
        {
            var uploadResult = _imageService.Upload(model.Images, "Hotel");
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var result = _hotelService.Edit(model);
        if (result.IsSuccess)
            return new JsonResult(new { status = "success", message = result.Message, redirectAction = "/Administration/HotelManagement/Index" });
        return new JsonResult(new { status = "error", message = ResponseMessage.OperationFailed });
    }

    public IActionResult Register()
    {
        var information = _hotelService.GetInformation();
        var model = new RegisterDto { Information = information };
        return View(model);
    }

    [HttpPost]
    public IActionResult Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
            return new JsonResult(new { status = "error", message = ResponseMessage.ModelNotValid });
        var imagesSrc = new List<string>();
        if (model.Images != null && model.Images.Count > 0)
        {
            var uploadResult = _imageService.Upload(model.Images, "Hotel");
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var result = _hotelService.Register(model);
        if (result.IsSuccess)
            return new JsonResult(new { status = "success", message = "", redirectAction = "/Administration/HotelManagement/Index" });
        return new JsonResult(new { status = "error", message = ResponseMessage.OperationFailed });
    }

    public IActionResult Detail(int id)
    {
        var hotel = _hotelService.GetDetail(id);
        return View(hotel);
    }

    public IActionResult RemoveImage(int id)
    {
        var result = _imageService.Remove(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = ResponseMessage.OperationFailed });
        return new JsonResult(new { status = "success" });
    }
}
