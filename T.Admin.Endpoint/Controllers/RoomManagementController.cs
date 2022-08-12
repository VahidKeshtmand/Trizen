using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Rooms;
using T.Application.Services.Hotels;
using T.Infrastructure.ImageServer;
using T.Infrastructure.Messages;

namespace T.Admin.Endpoint.Controllers;

public class RoomManagementController : Controller
{
    private readonly IRoomService _roomService;
    private readonly IImageUploadService _imageUploadService;

    public RoomManagementController(IRoomService roomService, IImageUploadService imageUploadService)
    {
        _roomService = roomService;
        _imageUploadService = imageUploadService;
    }

    public IActionResult NotFoundPage()
    {
        return View("NotFound");
    }

    public IActionResult Index(int hotelId, int page = 1, int pageSize = 100)
    {
        ViewBag.hotelId = hotelId;
        var result = _roomService.GetList(hotelId, page, pageSize);
        if (result.IsSuccess == false)
            return RedirectToAction(nameof(NotFoundPage));
        return View(result.Data);
    }

    public IActionResult Register(int id)
    {
        var information = _roomService.GetInformation(id);
        ViewBag.hotelId = information.Data.HotelId;
        var registerRoom = new RegisterRoomDto
        {
            Information = information.Data,
            HotelId = information.Data.HotelId,
        };
        return View(registerRoom);
    }

    [HttpPost]
    public IActionResult Register(RegisterRoomDto model)
    {
        if (!ModelState.IsValid)
            return new JsonResult(new { status = "error", message = ResponseMessage.ModelNotValid });
        var imagesSrc = new List<string>();
        if (model.Images != null && model.Images.Count > 0)
        {
            var uploadResult = _imageUploadService.Upload(model.Images, "Room", model.Name);
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var result = _roomService.Register(model);
        if (result.IsSuccess)
            return new JsonResult(new { status = "success", message = "", redirectAction = $"/RoomManagement/Index?hotelId={model.HotelId}" });
        return new JsonResult(new { status = "error", message = ResponseMessage.OperationFailed });

    }

    public IActionResult Edit(int id)
    {
        var information = _roomService.GetInformation(id);
        if (!information.IsSuccess)
            return RedirectToAction(nameof(NotFoundPage));
        ViewBag.hotelId = information.Data.HotelId;
        var room = _roomService.GetRoom(id);
        if (!room.IsSuccess)
            return RedirectToAction(nameof(NotFoundPage));
        var srcs = _roomService.GetImages(id);
        room.Data.ImagesSrc = srcs;
        room.Data.Information = new InformationRoomDto
        {
            Amenities = information.Data.Amenities,
            ServiceAmenities = information.Data.ServiceAmenities,

        };
        return View(room.Data);
    }

    [HttpPost]
    public IActionResult Edit(RoomEditDto model)
    {
        if (!ModelState.IsValid)
            return new JsonResult(new { status = "error", message = ResponseMessage.ModelNotValid });

        var imagesSrc = new List<string>();
        if (model.Images != null && model.Images.Count > 0)
        {
            var uploadResult = _imageUploadService.Upload(model.Images, "Room", model.Name);
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var result = _roomService.Edit(model);
        if (result.IsSuccess)
            return new JsonResult(new { status = "success", message = result.Message, redirectAction = $"/RoomManagement/Index?hotelId={model.HotelId}" });
        return new JsonResult(new { status = "error", message = ResponseMessage.OperationFailed });
    }

    public IActionResult Delete(int id)
    {
        var result = _roomService.Delete(id);
        if (result.IsSuccess == false)
            return new JsonResult(new { status = "error" });
        return new JsonResult(new { status = "success" });
    }

    public IActionResult Detail(int id)
    {
        var result = _roomService.GetDetail(id);
        if (result.IsSuccess == false)
            return RedirectToAction(nameof(NotFoundPage));
        return View(result.Data);
    }

}
