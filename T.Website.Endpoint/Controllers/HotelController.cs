using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Hotels;
using T.Application.Services.Hotels;
using T.Website.Endpoint.Utilities.Filters;

namespace T.Website.Endpoint.Controllers;

[ServiceFilter(typeof(SaveVisitorInfoFilter))]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public IActionResult RegisterHotel()
    {
        var jobsTitle = _hotelService.GetJobsTitleList();
        var countriesName = _hotelService.GetCountriesNameList();
        var countriesCode = _hotelService.GetCountriesCodeList();
        var currencies = _hotelService.GetCurrenciesList();
        var amenities = _hotelService.GetAmenitiesList();
        var model = new RegisterHotelDto
        {
            JobsTitle = jobsTitle,
            CountriesName = countriesName,
            CountriesCode = countriesCode,
            Currencies = currencies,
            Amenities = amenities
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult RegisterHotel(RegisterHotelDto model)
    {       
        if (!ModelState.IsValid)
            return new JsonResult(new { Status = "Fail", Message = "لطفاً فرم را به درستی پر کنید." });
        var result = _hotelService.Register(model);
        if (!result.IsSuccess)
            return new JsonResult(new { Status = "Fail" });
        return new JsonResult(new { Status = "Success" });
    }
}
