using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Discounts;
using T.Application.Services.Discounts;

namespace T.Admin.Endpoint.Controllers;

public class DiscountManagementController : Controller
{
    private readonly IDiscountService _discountService;

    public DiscountManagementController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public IActionResult Add(int hotelId, int roomId)
    {
        var existenceName = _discountService.GetExistenceName(roomId, hotelId);
        var roomHotelId = _discountService.GetHotelId(roomId);
        ViewBag.hotelId = roomHotelId;
        var model = new AddDiscountDto
        {
            ExistenceName = existenceName,
            RoomId = roomId,
            HotelId = hotelId
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(AddDiscountDto model)
    {
        var result = _discountService.Add(model);

        if (result.IsSuccess == false)
            return new JsonResult(new { status = "error", message = result.Message });
        if (model.HotelId != null && model.HotelId != 0)
            return new JsonResult(new { status = "success", redirectAction = $"/RoomManagement/Index?hotelId={model.HotelId}" });
        if (model.RoomId != null && model.RoomId != 0)
        {
            var roomHotelId = _discountService.GetHotelId(model.RoomId);
            return new JsonResult(new { status = "success", redirectAction = $"/RoomManagement/Index?hotelId={roomHotelId}" });
        }
        return new JsonResult(new { status = "error", message = "عملیات ناموفق !" });

    }

    public IActionResult Delete(int id)
    {
        var result = _discountService.Delete(id);
        if (result.IsSuccess == false)
            return new JsonResult(new { status = "error", message = result.Message });
        return new JsonResult(new { status = "success", message = result.Message });
    }

    public IActionResult Edit(int id)
    {
        var discount = _discountService.Find(id);
        return View(discount.Data);
    }

    [HttpPost]
    public IActionResult Edit(EditDiscountDto model)
    {
        var result = _discountService.Edit(model);

        if (result.IsSuccess == false)
            return new JsonResult(new { status = "error", message = "عملیات ناموفق !" });
        if (model.HotelId != 0)
            return new JsonResult(new { status = "success", redirectAction = $"/RoomManagement/Index?hotelId={model.HotelId}" });
        return new JsonResult(new { status = "error", message = "عملیات ناموفق !" });

    }
}
