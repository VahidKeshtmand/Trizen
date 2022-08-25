using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Common;
using T.Website.Endpoint.Models.Comments;
using T.Website.Endpoint.Models.Flights;

namespace T.Website.Endpoint.Services;

public interface IFlightServiceUI
{
    PaginatedItemsDto<FlightListViewModel> GetList(int pageIndex, int pageSize, FlightSearchModelDto searchModel);
    BaseDto<FlightDetailViewModel> GetDetail(string slug);
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
                LogoSrc = ComposeImageUri(x.AirlineCompany.Image.Src),
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

    private static List<string> ComposeImagesUri(List<string> imagesSrc)
    {
        var srcs = new List<string>();
        foreach (var src in imagesSrc)
        {
            srcs.Add("https://localhost:7235/" + src.Replace("\\", "//"));
        }

        return srcs;
    }

    private static string SetHourAndMinute(int minute)
    {
        var hours = (minute - minute % 60) / 60;
        return hours + ":" + (minute - hours * 60);
    }

    private static string ComposeImageUri(string imageSrc)
    {
        return "https://localhost:7235/" + imageSrc.Replace("\\", "//");
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
                FlightType = x.FlyingTo,
                TakeOff = x.TakeOffDate,
                Landing = x.LandingDate,
                Origin = x.FlyingFrom,
                Refundable = x.Refundable,
                TakeOffTime = x.TakeOffDate.Minute + " : " + x.TakeOffDate.Hour,
                FirstImage = ComposeImageUri(x.Images.Select(x => x.Src).FirstOrDefault() ?? ""),
                Images = ComposeImagesUri(x.Images.Select(x => x.Src).Skip(1).ToList()),
                Amenities = x.AmenityFlights.Select(x => x.Amenity.Title).ToList(),
                Id = x.Id,
                TotalTimeOfFlight = SetHourAndMinute(x.TotalTimeOfFlight)

            }).FirstOrDefault(x => x.Slug == slug);

        if (flight == null)
            return new BaseDto<FlightDetailViewModel>
            {
                IsSuccess = false
            };

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
}
