using Microsoft.AspNetCore.Mvc;
using OS.Application.Interfaces.Contexts;
using T.Website.Endpoint.Models.Hotel;

namespace T.Website.Endpoint.Controllers;

public class SearchHotelListViewComponent : ViewComponent
{
    private readonly IDatabaseContext _databaseContext;

    public SearchHotelListViewComponent(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IViewComponentResult Invoke()
    {
        var amenities = _databaseContext.Amenities.Select(x => new AmenityDto
        {
            Display = x.Display,
            Title = x.Title,
            Id = x.Id
        }).ToList();
        var model = new SearchHotel
        {
            Amenities = amenities
        };
        return View(model);
    }

}
