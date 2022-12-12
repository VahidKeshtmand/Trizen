using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Bookings;
using T.Application.Dtos.Common;
using T.Common;
using T.Domain.Bookings;
using T.Domain.Comments;

namespace T.Application.Services.Bookings;

public class BookingService : IBookingService
{
    public static string GetDisplayName(Enum enumValue)
    {
        if (enumValue == null) return "";
        var displayName = string.Empty;
        displayName = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
        if (String.IsNullOrEmpty(displayName))
        {
            displayName = enumValue.ToString();
        }
        return displayName;
    }
    private readonly IDatabaseContext _databaseContext;

    public BookingService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public BookingViewModel GetOrCreateBooking(string buyerId, int flightId, int quantity)
    {
        var booking = _databaseContext.Booking
            .Include(x => x.Flight)
            .ThenInclude(x => x.AirlineCompany)
            .ThenInclude(x => x.Image)
            .Include(x => x.Flight)
            .ThenInclude(x => x.Discounts)
            .Include(x => x.Flight)
            .ThenInclude(x => x.Comments)
            .SingleOrDefault(x => x.BuyerId == buyerId && x.FlightId == flightId);

        if (booking == null)
        {
            var newBooking = new Booking
            {
                BuyerId = buyerId,
                FlightId = flightId,
                SeatCount = quantity
            };
            _databaseContext.Booking.Add(newBooking);
            _databaseContext.SaveChanges();
            var findBooking = _databaseContext.Booking
                .Include(x => x.Flight)
                .ThenInclude(x => x.AirlineCompany)
                .Include(x => x.Flight)
                .ThenInclude(x => x.Discounts)
                .Select(x => new BookingViewModel
                {
                    Id = x.Id,
                    BasePrice = x.Flight.BasePrice,
                    Discounts = x.Flight.Discounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => x.Percent).ToList(),
                    Coach = GetDisplayName(x.Flight.Coach),
                    AirlineCompanyName = x.Flight.AirlineCompany.Name,
                    Destination = x.Flight.FlyingFrom,
                    Origin = x.Flight.FlyingTo,
                    ExtraFee = x.Flight.TaxesAndFees,
                    FlightType = GetDisplayName(x.Flight.FlightType),
                    ImageSrc = x.Flight.AirlineCompany.Image.Src,
                    Landing = x.Flight.LandingDate.ToFarsi(),
                    TakeOff = x.Flight.TakeOffDate.ToFarsi(),
                    TakeOffTime = x.Flight.TakeOffDate.Minute + " : " + x.Flight.TakeOffDate.Hour,
                    TotalTimeOfFlight = SetHourAndMinute(x.Flight.TotalTimeOfFlight),
                    FlightId = x.Flight.Id,
                    SeatCount = x.SeatCount,
                    TotalPrice = (x.Flight.TaxesAndFees + x.Flight.BasePrice) * (quantity + x.SeatCount),
                    Rate = GetAverageRate(x.Flight.Comments.ToList()),
                    CommentCount = x.Flight.Comments.Count()
                }).SingleOrDefault(x => x.Id == newBooking.Id);


            if (findBooking.Discounts.Count() > 0)
            {
                var discount = findBooking.Discounts.LastOrDefault();
                findBooking.TotalPriceWithDiscount = (((100 - discount) * 0.01) * (findBooking.BasePrice + findBooking.ExtraFee)) * quantity;
            }
            return findBooking;
        }

        booking.SeatCount += quantity;
        _databaseContext.SaveChanges();
        var flight = new BookingViewModel
        {
            BasePrice = booking.Flight.BasePrice,
            Discounts = booking.Flight.Discounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => x.Percent).ToList(),
            Coach = GetDisplayName(booking.Flight.Coach),
            AirlineCompanyName = booking.Flight.AirlineCompany.Name,
            Destination = booking.Flight.FlyingFrom,
            Origin = booking.Flight.FlyingTo,
            ExtraFee = booking.Flight.TaxesAndFees,
            FlightType = GetDisplayName(booking.Flight.FlightType),
            ImageSrc = ComposeImageUri(booking.Flight.AirlineCompany.Image.Src),
            Landing = booking.Flight.LandingDate.ToFarsi(),
            TakeOff = booking.Flight.TakeOffDate.ToFarsi(),
            TakeOffTime = booking.Flight.TakeOffDate.Minute + " : " + booking.Flight.TakeOffDate.Hour,
            TotalTimeOfFlight = SetHourAndMinute(booking.Flight.TotalTimeOfFlight),
            FlightId = booking.Flight.Id,
            SeatCount = booking.SeatCount,
            TotalPrice = (booking.Flight.TaxesAndFees + booking.Flight.BasePrice) * booking.SeatCount,
            Rate = GetAverageRate(booking.Flight.Comments.ToList()),
            CommentCount = booking.Flight.Comments.Count()
        };
        if (flight.Discounts.Count() > 0)
        {
            var discount = flight.Discounts.LastOrDefault();
            flight.TotalPriceWithDiscount = (((100 - discount) * 0.01) * (flight.BasePrice + flight.ExtraFee)) * quantity;
        }
        return flight;
    }
    public static double GetAverageRate(List<Comment> model)
    {
        var rateList = new List<int>();
        foreach (var item in model)
        {
            rateList.Add(item.ServiceRate);
            rateList.Add(item.FacilityRate);
            rateList.Add(item.LocationRate);
            rateList.Add(item.ValueForMoneyService);
        }
        if (rateList.Count() <= 0)
            return 0;
        return rateList.Average();

    }

    private static string ComposeImageUri(string? imageSrc)
    {
        if (imageSrc == null) return "";
        return "https://localhost:7235/" + imageSrc.Replace("\\", "//");
    }

    private static int AddQuantity(int newQuantity, int oldQuantity)
    {
        var result = oldQuantity;
        result += newQuantity;
        return result;
    }

    private static string SetHourAndMinute(int minute)
    {
        var hours = (minute - minute % 60) / 60;
        return hours + ":" + (minute - hours * 60);
    }
    public void TransferBooking(string anonymousId, string userId)
    {
        var anonymousBooking = _databaseContext.Booking
            .Where(x => x.BuyerId == anonymousId).ToList();

        if (anonymousBooking == null) return;
        var userBooking = _databaseContext.Booking
            .Where(x => x.BuyerId == userId).ToList();

        foreach (var item in anonymousBooking)
        {
            var flightExist = _databaseContext.Booking.FirstOrDefault(x => x.FlightId == item.FlightId);
            if (flightExist != null)
            {
                flightExist.SeatCount += item.SeatCount;
                continue;
            }

            _databaseContext.Booking.Add(new Booking
            {
                BuyerId = userId,
                FlightId = item.FlightId,
                SeatCount = item.SeatCount
            });
        }

        _databaseContext.Booking.RemoveRange(anonymousBooking);
        _databaseContext.SaveChanges();
    }

    public BaseDto DeleteBooking(int bookingId)
    {
        throw new NotImplementedException();
    }

    public bool CheckQuantity(int flightId, int quantity)
    {
        var flight = _databaseContext.Flights.Select(x => new { x.Id, x.SeatNumber }).FirstOrDefault(x => x.Id == flightId);
        if (flight == null) return false;
        if (quantity > flight.SeatNumber) return false;
        return true;
    }
}

public interface IBookingService
{
    void TransferBooking(string anonymousId, string userId);
    BaseDto DeleteBooking(int bookingId);
    public BookingViewModel GetOrCreateBooking(string buyerId, int flightId, int quantity);
    bool CheckQuantity(int flightId, int quantity);
}


