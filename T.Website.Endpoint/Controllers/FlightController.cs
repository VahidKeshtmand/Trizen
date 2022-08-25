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
}
