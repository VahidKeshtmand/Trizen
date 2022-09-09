using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OS.Application.Interfaces.Contexts;
using OS.Website.EndPoint.Utilities;
using T.Application.Dtos.Bookings;
using T.Application.Services.Bookings;
using T.Domain.Account;
using T.Website.Endpoint.Models.Flights;

namespace T.Website.Endpoint.Controllers;

public class BookingController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly SignInManager<User> _signInManager;
    private string UserId = null;

    public BookingController(IBookingService bookingService, SignInManager<User> signInManager)
    {
        _bookingService = bookingService;
        _signInManager = signInManager;
    }
    [TempData]
    public string Message { get; set; }
    public IActionResult Index(ReserveFlightTicketPartOneForm model)
    {
        var isOutOfSeatNumber = _bookingService.CheckQuantity(model.FlightId, model.SeatCount);
        if (!isOutOfSeatNumber)
        {
            Message = "تعداد صندلی درخواستی موجود نیست !";
            return Redirect($"/Flight/Details/{model.FlightSlug}");
        }
        var booking = GetOrSetBooking(model.FlightId, model.SeatCount);
        return View(booking);

    }

    private BookingViewModel GetOrSetBooking(int flightId, int quantity)
    {
        if (_signInManager.IsSignedIn(User))
        {
            UserId = ClaimUtility.GetUserId(User);
            return _bookingService.GetOrCreateBooking(UserId, flightId, quantity);
        }
        SetCookieForBooking();
        return _bookingService.GetOrCreateBooking(UserId, flightId, quantity);
    }

    private void SetCookieForBooking()
    {
        var bookingCookieName = "bookingId";
        if (Request.Cookies.ContainsKey(bookingCookieName))
        {
            UserId = Request.Cookies[bookingCookieName];
        }
        if (UserId != null) return;
        UserId = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Today.AddYears(2) };
        Response.Cookies.Append(bookingCookieName, UserId, cookieOptions);
    }
}
