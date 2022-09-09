using Microsoft.AspNetCore.Mvc;
using T.Application.Services.Visitor;

namespace T.Website.Endpoint.Areas.Administration.Controllers;

[Area("Administration")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVisitorService _visitorService;
    private readonly IOnlineVisitorService _onlineVisitorService;

    public HomeController(ILogger<HomeController> logger, IVisitorService visitorService, IOnlineVisitorService onlineVisitorService)
    {
        _logger = logger;
        _visitorService = visitorService;
        _onlineVisitorService = onlineVisitorService;
    }

    public IActionResult Index()
    {
        var result = _visitorService.GetTodayReport();
        return View(result);
    }

    [HttpPost]
    public IActionResult GetOnlineVisitorCount()
    {
        var visitorId = HttpContext.Request.Cookies["VisitorId"];
        var count = _onlineVisitorService.GetCount(visitorId);
        return new JsonResult(new { count = count });
    }

    public IActionResult Privacy()
    {
        return View();
    }
}

