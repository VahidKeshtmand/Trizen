using Microsoft.AspNetCore.Mvc;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Baskets;

namespace T.Website.Endpoint.Component;

public class AddRoomToBasketViewComponent : ViewComponent
{
    private readonly IDatabaseContext _databaseContext;

    public AddRoomToBasketViewComponent(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IViewComponentResult Invoke(int id)
    {
        var room = _databaseContext.Rooms.FirstOrDefault(x => x.Id == id);
        var basketInfo = new BasketItemDto
        {
            Quantity = room.Count,
            Id = room.Id,
            BedNumber = room.BedCount
        };
        return View(basketInfo);
    }
}
