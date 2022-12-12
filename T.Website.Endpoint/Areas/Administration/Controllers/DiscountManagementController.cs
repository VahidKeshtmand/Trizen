using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Discounts;
using T.Application.Services.Discounts;

namespace T.Admin.Endpoint.Controllers;

[Area("Administration")]
public class DiscountManagementController : Controller
{
    private readonly IDiscountService _discountService;

    public DiscountManagementController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public IActionResult Add(int hotelId, int roomId, int flightId)
    {
        var existenceName = _discountService.GetExistenceName(roomId, hotelId);
        var roomHotelId = _discountService.GetHotelId(roomId);
        ViewBag.hotelId = roomHotelId;
        var model = new AddDiscountDto
        {
            ExistenceName = existenceName,
            RoomId = roomId,
            HotelId = hotelId,
            FlightId = flightId
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
            return new JsonResult(new { status = "success", redirectAction = $"/Administration/RoomManagement/Index?hotelId={model.HotelId}" });
        if (model.RoomId != null && model.RoomId != 0)
        {
            var roomHotelId = _discountService.GetHotelId(model.RoomId);
            return new JsonResult(new { status = "success", redirectAction = $"/Administration/RoomManagement/Index?hotelId={roomHotelId}" });
        }
        if (model.FlightId != null)
        {
            var airlineCompanyId = _discountService.GetAirlineCompanyId(model.FlightId);
            return new JsonResult(new { status = "success", redirectAction = $"/Administration/FlightManagement/FlightList?airlineCompanyId={airlineCompanyId}" });
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
        if (model.HotelId != 0 && model.HotelId != null)
            return new JsonResult(new { status = "success", redirectAction = $"/Administration/RoomManagement/Index?hotelId={model.HotelId}" });
        if (model.FlightId != null)
        {
            var airlineCompanyId = _discountService.GetAirlineCompanyId(model.FlightId);
            return new JsonResult(new { status = "success", redirectAction = $"/Administration/FlightManagement/FlightList?airlineCompanyId={airlineCompanyId}" });
        }
        return new JsonResult(new { status = "error", message = "عملیات ناموفق !" });

    }
}
