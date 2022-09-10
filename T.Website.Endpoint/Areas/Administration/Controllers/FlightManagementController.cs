using Microsoft.AspNetCore.Mvc;
using T.Application.Dtos.Flights;
using T.Application.Images;
using T.Application.Services.Flights;
using T.Infrastructure.ImageServer;

namespace T.Admin.Endpoint.Controllers;

[Area("Administration")]
public class FlightManagementController : Controller
{
    private readonly IFlightService _flightService;
    private readonly IImageService _imageService;
    public FlightManagementController(IFlightService flightService, IImageService imageService)
    {
        _flightService = flightService;
        _imageService = imageService;
    }

    public IActionResult Index(string searchKey, int page = 1, int pageSize = 20)
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
            var uploadResult = _imageService.Upload(list, "AirlineCompany");
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImageSrc = imagesSrc.FirstOrDefault() ?? "";
        var result = _flightService.AddAirlineCompany(model);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = "عملیات ناموفق !" });
        return new JsonResult(new { status = "success", redirectAction = "/Administration/FlightManagement/Index" });
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
        airlineCompany.Data.ImagesModel = _flightService.GetImagesAirlineCompany(id);
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
            var checkLogo = _flightService.CheckLogo(model.Id);
            if (checkLogo > 0)
            {
                _imageService.Remove(checkLogo);
            }
            var uploadResult = _imageService.Upload(list, "AirlineCompany");
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImageSrc = imagesSrc.FirstOrDefault() ?? "";
        var result = _flightService.EditAirlineCompany(model);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = result.Message });

        return new JsonResult(new { status = "success", redirectAction = "/Administration/FlightManagement/Index" });
    }

    public IActionResult FlightList(int airlineCompanyId, string searchKey, int pageIndex = 1, int pageSize = 20)
    {
        var list = _flightService.GetFlightsList(airlineCompanyId, searchKey, pageIndex, pageSize);
        var airlineCompanyName = _flightService.FindAirlineCompanyName(airlineCompanyId);
        if (!airlineCompanyName.IsSuccess)
            return NotFound();
        var model = new FlightListPageDto
        {
            AirlineCompanyId = airlineCompanyId,
            AirlineCompanyName = airlineCompanyName.Data,
            Flights = list
        };
        return View(model);
    }

    public IActionResult AddFlight(int airlineCompanyId)
    {
        if (airlineCompanyId == null || airlineCompanyId == 0)
            return NotFound();

        var info = _flightService.GetInformation();
        var flight = new AddFlightDto
        {
            AirlineCompanyId = airlineCompanyId,
            Information = new InformationForAddFlightDto
            {
                Amenities = info.Amenities,
                Currencies = info.Currencies
            }
        };
        return View(flight);
    }

    [HttpPost]
    public JsonResult AddFlight(AddFlightDto model)
    {
        var imagesSrc = new List<string>();
        if (model.Images != null)
        {
            var list = new List<IFormFile>();
            list.AddRange(model.Images);
            var uploadResult = _imageService.Upload(list, "Flight");
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var flight = _flightService.AddFlight(model);
        if (!flight.IsSuccess)
            return new JsonResult(new { status = "error", message = flight.Message });

        return new JsonResult(new { status = "success", redirectAction = $"/Administration/FlightManagement/FlightList?airlineCompanyId={model.AirlineCompanyId}" });
    }

    public IActionResult EditFlight(int id, int airlineCompanyId)
    {
        if (airlineCompanyId == null || airlineCompanyId == 0)
            return NotFound();

        var flight = _flightService.FindFlight(id);
        if (!flight.IsSuccess)
            return NotFound();
        flight.Data.Information = _flightService.GetInformation();
        flight.Data.AirlineCompanyId = airlineCompanyId;
        flight.Data.ImagesModel = _flightService.GetImages(id);
        return View(flight.Data);
    }

    [HttpPost]
    public JsonResult EditFlight(EditFlightDto model)
    {
        var imagesSrc = new List<string>();
        if (model.Images != null)
        {
            var list = new List<IFormFile>();
            list.AddRange(model.Images);
            var uploadResult = _imageService.Upload(list, "Flight");
            foreach (var src in uploadResult)
            {
                imagesSrc.Add(src);
            }
        }
        model.ImagesSrc = imagesSrc;
        var flight = _flightService.EditFlight(model);
        if (!flight.IsSuccess)
            return new JsonResult(new { status = "error", message = flight.Message });

        return new JsonResult(new { status = "success", redirectAction = $"/FlightManagement/FlightList?airlineCompanyId={model.AirlineCompanyId}" });
    }

    public IActionResult DeleteFlight(int id)
    {
        var result = _flightService.DeleteFlight(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = result.Message });

        return new JsonResult(new { status = "success", message = result.Message });
    }
}
