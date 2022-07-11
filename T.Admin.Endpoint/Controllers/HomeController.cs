using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using T.Admin.Endpoint.Models;
using T.Application.Services.Visitor;

namespace T.Admin.Endpoint.Controllers
{
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
            var vistitorId = HttpContext.Request.Cookies["VisitorId"];
            var count = _onlineVisitorService.GetCount(vistitorId);
            return new JsonResult(new { count = count });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}