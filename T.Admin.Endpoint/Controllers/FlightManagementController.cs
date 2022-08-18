using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Flights;
using T.Application.Services.Flights;
using T.Infrastructure.ImageServer;

namespace T.Admin.Endpoint.Controllers;

public class FlightManagementController : Controller
{
    private readonly IFlightService _flightService;
    private readonly IImageUploadService _imageUploadService;
    public FlightManagementController(IFlightService flightService, IImageUploadService imageUploadService)
    {
        _flightService = flightService;
        _imageUploadService = imageUploadService;
    }

    public IActionResult Index(string searchKey, int page = 1, int pageSize = 100)
    {
        var airlineCompanies = _flightService.GetAirlineCompanyList(searchKey, page, pageSize);
        return View(airlineCompanies);
    }

    public IActionResult AddAirlineCompany()
    {
        return View();
    }

    [HttpPost]
    public JsonResult AddAirlineCompany(AddAirlineCompanyDto model)
    {
        var imagesSrc = new List<string>();
        var list = new List<IFormFile>();
        list.Add(model.Logo);
        if (model.Logo != null)
        {
            var uploadResult = _imageUploadService.Upload(list, "AirlineCompany", model.Name);
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImageSrc = imagesSrc.FirstOrDefault() ?? "";
        var result = _flightService.AddAirlineCompany(model);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = "عملیات ناموفق !" });
        return new JsonResult(new { status = "success", redirectAction = "/FlightManagement/Index" });
    }

    public IActionResult DeleteAirlineCompany(int id)
    {
        var result = _flightService.DeleteAirlineCompany(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = result.Message });
        return new JsonResult(new { status = "success", message = result.Message });

    }

    public IActionResult EditAirlineCompany(int id)
    {
        var airlineCompany = _flightService.FindAirlineCompany(id);
        return View(airlineCompany.Data);
    }

    [HttpPost]
    public IActionResult EditAirlineCompany(EditAirlineCompanyDto model)
    {
        var imagesSrc = new List<string>();
        var list = new List<IFormFile>();
        list.Add(model.Logo);
        if (model.Logo != null)
        {
            var uploadResult = _imageUploadService.Upload(list, "AirlineCompany", model.Name);
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImageSrc = imagesSrc.FirstOrDefault() ?? "";
        var result = _flightService.EditAirlineCompany(model);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = result.Message });

        return new JsonResult(new { status = "success", redirectAction = "/FlightManagement/Index" });
    }
}
