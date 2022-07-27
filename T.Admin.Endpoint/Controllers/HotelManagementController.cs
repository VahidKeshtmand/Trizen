using Microsoft.AspNetCore.Mvc;
using T.Application.Services.Hotels;

namespace T.Admin.Endpoint.Controllers;

public class HotelManagementController : Controller
{
    private readonly IHotelService _hotelService;

    public HotelManagementController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public IActionResult RequestHotelList()
    {
        var list = _hotelService.GetRequestList();
        return View(list);
    }

}
