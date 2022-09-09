using Microsoft.AspNetCore.Mvc;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Rooms;

namespace T.Website.Endpoint.Controllers;

public class SearchForHotelRoomsViewComponent : ViewComponent
{

    public IViewComponentResult Invoke(string slug)
    {
        var model = new SearchRoomDto
        {
            Slug = slug
        };
        return View(model);
    }

}
