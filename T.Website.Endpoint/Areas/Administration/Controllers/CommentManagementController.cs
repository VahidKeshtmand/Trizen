using Microsoft.AspNetCore.Mvc;
using T.Application.Services.Comments;

namespace T.Admin.Endpoint.Controllers;

[Area("Administration")]
public class CommentManagementController : Controller
{
    private readonly ICommentService _commentService;

    public CommentManagementController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IActionResult Index(int pageIndex = 1, int pageSize = 20)
    {
        var list = _commentService.GetList(pageIndex, pageSize);
        return View(list);
    }

    public IActionResult Delete(int id)
    {
        var result = _commentService.Delete(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = result.Message });
        return new JsonResult(new { status = "success", message = result.Message }); ;
    }

    public IActionResult Confirmed(int id)
    {
        var result = _commentService.Confirmed(id);
        if (!result.IsSuccess)
            return new JsonResult(new { status = "error", message = result.Message });
        return new JsonResult(new { status = "success", message = result.Message }); ;
    }
}
