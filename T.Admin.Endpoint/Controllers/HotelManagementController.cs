using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Hotels;
using T.Application.Services.Hotels;
using T.Infrastructure.ImageServer;
using T.Infrastructure.Messages;

namespace T.Admin.Endpoint.Controllers;

public class HotelManagementController : Controller
{
    private readonly IHotelService _hotelService;
    private readonly IImageUploadService _imageUploadService;

    public HotelManagementController(IHotelService hotelService, IImageUploadService imageUploadService)
    {
        _hotelService = hotelService;
        _imageUploadService = imageUploadService;
    }

    public IActionResult Index(int page = 1, int pageSize = 100)
    {
        var list = _hotelService.GetList(page, pageSize);
        return View(list);
    }

    [HttpPost]
    public IActionResult Confirm(int id)
    {
        var result = _hotelService.ConfirmStatusMethod(id);
        if (result == true)
            return new JsonResult(new { status = "success" });
        return new JsonResult(new { status = "error" });
    }

    [HttpPost]
    public IActionResult Reject(int id)
    {
        var result = _hotelService.RejectStatusMethod(id);
        if (result == true)
            return new JsonResult(new { status = "success" });
        return new JsonResult(new { status = "error" });
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
        hotel.ImagesSrc = srcs;
        hotel.Information = new InformationDto
        {
            Amenities = information.Amenities,
            CountriesCode = information.CountriesCode,
            CountriesName = information.CountriesName,
            Currencies = information.Currencies,
            JobTitles = information.JobTitles
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
            var uploadResult = _imageUploadService.Upload(model.Images, "Hotel", model.Name);
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var result = _hotelService.Edit(model);
        if (result.IsSuccess)
            return new JsonResult(new { status = "success", message = result.Message, redirectAction = "/HotelManagement/Index" });
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
            var uploadResult = _imageUploadService.Upload(model.Images, "Hotel", model.Name);
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var result = _hotelService.Register(model);
        if (result.IsSuccess)
            return new JsonResult(new { status = "success", message = "", redirectAction = "/HotelManagement/List" });
        return new JsonResult(new { status = "error", message = ResponseMessage.OperationFailed });
    }

    public IActionResult Detail(int id)
    {
        var hotel = _hotelService.GetDetail(id);
        return View(hotel);
    }
}
