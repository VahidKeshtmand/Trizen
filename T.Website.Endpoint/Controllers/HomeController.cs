using Microsoft.AspNetCore.Mvc;
using T.Website.Endpoint.Models.Comments;
using T.Website.Endpoint.Services;
using T.Website.Endpoint.Utilities.Filters;

namespace T.Website.Endpoint.Controllers
{
    // [ServiceFilter(typeof(SaveVisitorInfoFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommentServiceUI _commentController;
        public HomeController(ILogger<HomeController> logger, ICommentServiceUI commentController)
        {
            _logger = logger;
            _commentController = commentController;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddComment(AddCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new { status = "error", message = "فرم ارسال نظر را به درستی پر کنید !" });
            var result = _commentController.AddComment(model);
            if (!result.IsSuccess)
                return new JsonResult(new { status = "error", message = result.Message });
            return new JsonResult(new { status = "success", message = result.Message });
        }

        [HttpPost]
        public IActionResult AddCommentFlight(AddCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new { status = "error", message = "فرم ارسال نظر را به درستی پر کنید !" });
            var result = _commentController.AddComment(model);
            if (!result.IsSuccess)
                return new JsonResult(new { status = "error", message = result.Message });
            return new JsonResult(new { status = "success", message = result.Message });
        }
    }
}