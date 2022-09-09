using Microsoft.AspNetCore.Mvc;
using T.Website.Endpoint.Models.Flights;
using T.Website.Endpoint.Services;

namespace T.Website.Endpoint.Controllers;

public class FlightController : Controller
{
    private readonly IFlightServiceUI _flightService;

    public FlightController(IFlightServiceUI flightService)
    {
        _flightService = flightService;
    }

    public IActionResult Index(FlightSearchModelDto searchModel, int pageIndex = 1, int pageSize = 20)
    {
        var list = _flightService.GetList(pageIndex, pageSize, searchModel);
        return View(list);
    }

    public IActionResult Details(string id)
    {
        var result = _flightService.GetDetail(id);
        if (!result.IsSuccess)
            return NotFound();

        return View(result.Data);
    }

    // [TempData]
    // public string Message { get; set; }
    // public IActionResult Booking(ReserveFlightTicketPartOneForm model)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest();
    //     var isOutOfSeatNumber = _flightService.CheckExistSeat(model.FlightId, model.SeatCount);
    //     var slug = _flightService.GetSlug(model.FlightId);
    //     if (!isOutOfSeatNumber)
    //     {
    //         Message = "تعداد صندلی درخواستی موجود نیست !";
    //         return Redirect($"/Flight/Details/{slug}");
    //     }
    //     // var result = _flightService.GetBookingInformation(model.FlightId, model.SeatCount);
    //     if (!result.IsSuccess)
    //     {
    //         Message = "پرواز مورد نظر یافت نشد!";
    //         return Redirect($"/Flight/Details/{slug}");
    //     }
    //     return View(result.Data);
    // }
}
