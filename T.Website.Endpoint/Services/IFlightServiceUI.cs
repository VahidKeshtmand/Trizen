using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Bookings;
using T.Application.Dtos.Common;
using T.Common;
using T.Domain.Comments;
using T.Website.Endpoint.Models.Comments;
using T.Website.Endpoint.Models.Flights;

namespace T.Website.Endpoint.Services;

public interface IFlightServiceUI
{
    PaginatedItemsDto<FlightListViewModel> GetList(int pageIndex, int pageSize, FlightSearchModelDto searchModel);
    BaseDto<FlightDetailViewModel> GetDetail(string slug);
    bool CheckExistSeat(int flightId, int requestNumber);
    BaseDto<BookingViewModel> GetBookingInformation(int flightId, int seatNumber);
    string GetSlug(int id);
}

public class FlightServiceUI : IFlightServiceUI
{
    private readonly IDatabaseContext _databaseContext;

    public FlightServiceUI(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public PaginatedItemsDto<FlightListViewModel> GetList(int pageIndex, int pageSize, FlightSearchModelDto searchModel)
    {
        var rowCount = 0;
        var flights = _databaseContext.Flights
            .Include(x => x.AirlineCompany)
            .ThenInclude(x => x.Image)
            .ToPaged(pageIndex, pageSize, out rowCount)
            .Select(x => new FlightListViewModel
            {
                Slug = x.Slug,
                AirlineCompanyName = x.AirlineCompany.Name,
                Destination = x.FlyingTo,
                FlightType = x.FlightType,
                Landing = x.LandingDate,
                LogoSrc = x.AirlineCompany.Image.Src,
                Price = x.PriceRange,
                TakeOff = x.TakeOffDate,
                TotalTimeOfFlight = SetHourAndMinute(x.TotalTimeOfFlight),
                TakeOffTime = x.TakeOffDate.Minute + " : " + x.TakeOffDate.Hour,
            });

        if (searchModel.LandingDate != null)
        {
            flights = flights.Where(x => x.Landing.ToShamsi() == searchModel.LandingDate);
        }
        if (searchModel.TakeOffDate != null)
        {
            flights = flights.Where(x => x.TakeOff.ToShamsi() == searchModel.TakeOffDate);
        }
        if (searchModel.AirlineCompany != null)
        {
            flights = flights.Where(x => x.AirlineCompanyName.Contains(searchModel.AirlineCompany));
        }
        if (searchModel.Destination != null)
        {
            flights = flights.Where(x => x.Destination.Contains(searchModel.Destination));
        }
        return new PaginatedItemsDto<FlightListViewModel>(pageIndex, pageSize, rowCount, flights.ToList());

    }

    private static string SetHourAndMinute(int minute)
    {
        var hours = (minute - minute % 60) / 60;
        return hours + ":" + (minute - hours * 60);
    }

    public BaseDto<FlightDetailViewModel> GetDetail(string slug)
    {
        var flight = _databaseContext.Flights
            .Include(x => x.AirlineCompany)
            .Include(x => x.Images)
            .Include(x => x.Comments)
            .Include(x => x.AmenityFlights)
            .ThenInclude(x => x.Amenity)
            .Select(x => new FlightDetailViewModel
            {
                AirlineCompanyName = x.AirlineCompany.Name,
                AirlineCompanyDescription = x.AirlineCompany.Description,
                Coach = x.Coach,
                BasePrice = x.BasePrice,
                Destination = x.FlyingTo,
                ExtraFee = x.TaxesAndFees,
                Slug = x.Slug,
                CancellationCharge = x.CancellationCharge,
                FlightType = GetDisplayName(x.FlightType),
                TakeOff = x.TakeOffDate,
                Landing = x.LandingDate,
                Origin = x.FlyingFrom,
                Refundable = x.Refundable,
                TakeOffTime = x.TakeOffDate.Minute + " : " + x.TakeOffDate.Hour,
                FirstImage = x.Images.Select(x => x.Src).FirstOrDefault() ?? "",
                Images = x.Images.Select(x => x.Src).Skip(1).ToList(),
                Amenities = x.AmenityFlights.Select(x => x.Amenity.Title).ToList(),
                Id = x.Id,
                TotalTimeOfFlight = SetHourAndMinute(x.TotalTimeOfFlight),
                Discounts = x.Discounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => x.Percent).ToList(),


            }).FirstOrDefault(x => x.Slug == slug);

        if (flight == null)
            return new BaseDto<FlightDetailViewModel>
            {
                IsSuccess = false
            };

        if (flight.Discounts.Count() > 0)
        {
            var discount = flight.Discounts.LastOrDefault();
            flight.PriceWithDiscount = (((100 - discount) * 0.01) * (flight.BasePrice)).ToString("n0");
        }

        flight.Comments = _databaseContext.Comments
            .Where(x => x.FlightId == flight.Id)
            .Select(x => new CommentViewModel
            {
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Rate = x.ServiceRate,
                Date = EF.Property<DateTime>(x, "InsertDate").ToFarsi()
            }).ToList();

        return new BaseDto<FlightDetailViewModel>
        {
            Data = flight,
            IsSuccess = true,
        };

    }

    public bool CheckExistSeat(int flightId, int requestNumber)
    {
        var flight = _databaseContext.Flights.Select(x => new { x.SeatNumber, x.Id }).FirstOrDefault(x => x.Id == flightId);
        if (flight == null) return false;
        if (flight.SeatNumber < requestNumber) return false;
        return true;
    }

    public BaseDto<BookingViewModel> GetBookingInformation(int flightId, int seatNumber)
    {
        var flight = _databaseContext.Flights
            .Include(x => x.AirlineCompany)
            .ThenInclude(x => x.Image)
            .Include(x => x.Discounts)
            .Include(x => x.Comments)
            .Select(x => new BookingViewModel
            {
                BasePrice = x.BasePrice,
                Discounts = x.Discounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => x.Percent).ToList(),
                Coach = GetDisplayName(x.Coach),
                AirlineCompanyName = x.AirlineCompany.Name,
                Destination = x.FlyingFrom,
                Origin = x.FlyingTo,
                ExtraFee = x.TaxesAndFees,
                FlightType = GetDisplayName(x.FlightType),
                ImageSrc = x.AirlineCompany.Image.Src,
                Landing = x.LandingDate.ToFarsi(),
                TakeOff = x.TakeOffDate.ToFarsi(),
                TakeOffTime = x.TakeOffDate.Minute + " : " + x.TakeOffDate.Hour,
                TotalTimeOfFlight = SetHourAndMinute(x.TotalTimeOfFlight),
                FlightId = x.Id,
                SeatCount = seatNumber,
                TotalPrice = (x.TaxesAndFees + x.BasePrice) * seatNumber,
                Rate = GetAverageRate(x.Comments.ToList()),
                CommentCount = x.Comments.Count()
            }).FirstOrDefault(x => x.FlightId == flightId);

        if (flight == null)
            return new BaseDto<BookingViewModel>
            {
                IsSuccess = false
            };

        if (flight.Discounts.Count() > 0)
        {
            var discount = flight.Discounts.LastOrDefault();
            flight.TotalPriceWithDiscount = (((100 - discount) * 0.01) * (flight.BasePrice + flight.ExtraFee)) * seatNumber;
        }

        return new BaseDto<BookingViewModel>
        {
            Data = flight,
            IsSuccess = true
        };

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

    public static string GetDisplayName(Enum enumValue)
    {
        string displayName;
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

    public string GetSlug(int id)
    {
        return _databaseContext.Flights.Select(x => new { x.Slug, x.Id }).FirstOrDefault(x => x.Id == id)?.Slug;
    }
}
