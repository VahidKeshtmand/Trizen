using Microsoft.AspNetCore.Mvc;
using T.Website.Endpoint.Models.Hotel;
using T.Website.Endpoint.Services;

namespace T.Website.Endpoint.Controllers;

public class HotelController : Controller
{
    private readonly IHotelServiceUI _hotelService;

    public HotelController(IHotelServiceUI hotelService)
    {
        _hotelService = hotelService;
    }

    public IActionResult Index(SearchHotel searchModel, int pageIndex = 1, int pageSize = 5)
    {
        var hotelList = _hotelService.Search(searchModel, pageIndex, pageSize);
        return View(hotelList);
    }

    public IActionResult Detail(string slug, string city)
    {
        var hotel = _hotelService.GetDetails(slug);
        return View(hotel.Data);
    }

    public IActionResult RoomsList(string hotelSlug, int pageIndex = 1, int pageSize = 1)
    {
        ViewBag.hotelName = _hotelService.GetHotelName(hotelSlug).Data;
        var roomsList = _hotelService.GetRoomsList(hotelSlug, pageIndex, pageSize);
        return View(roomsList);
    }

    public IActionResult RoomDetails(string hotelSlug, string roomSlug)
    {
        var roomsList = _hotelService.GetRoomDetails(roomSlug);
        if (!roomsList.IsSuccess)
            return NotFound();
        return View(roomsList.Data);
    }
}
