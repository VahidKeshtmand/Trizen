using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using OS.Application.Interfaces.Contexts;
using T.Website.Endpoint.Models.Hotel;
using T.Domain.Common;

namespace T.Website.Endpoint.Component;

public class SearchHotelListViewComponent : ViewComponent
{
    private readonly IDatabaseContext _databaseContext;

    public SearchHotelListViewComponent(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IViewComponentResult Invoke()
    {
        var amenities = _databaseContext.Amenities.Where(x => x.AmenityType == AmenityType.Hotel)
            .Select(x => new AmenityDto
            {
                Display = x.Display,
                Title = x.Title,
                Id = x.Id
            }).ToList();
        var searchModel = new SearchHotel
        {
            Amenities = amenities,
        };
        return View(searchModel);
    }
}
