using Microsoft.AspNetCore.Mvc;
using OS.Application.Interfaces.Contexts;
using T.Website.Endpoint.Models.Flights;

namespace T.Website.Endpoint.Component;

public class ReservePlaneTicketFormViewComponent : ViewComponent
{
    private readonly IDatabaseContext _databaseContext;

    public ReservePlaneTicketFormViewComponent(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IViewComponentResult Invoke(int id)
    {
        var slug = _databaseContext.Flights.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        var model = new ReserveFlightTicketPartOneForm
        {
            FlightId = id,
            FlightSlug = slug
        };
        return View(model);
    }
}
