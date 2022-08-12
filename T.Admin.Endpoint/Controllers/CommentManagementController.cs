using Microsoft.AspNetCore.Mvc;

namespace T.Admin.Endpoint.Controllers;

public class CommentManagementController : Controller
{
    public IActionResult Index(int pageIndex = 1, int pageSize = 20)
    {
        return View();
    }

}
