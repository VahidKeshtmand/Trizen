using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Dtos.Flights;
using T.Application.Dtos.Hotels;
using T.Common;
using T.Domain.Common;
using T.Domain.Flights;

namespace T.Application.Services.Flights;

public interface IFlightService
{
    List<ImageDto> GetImages(int id);
    List<ImageDto> GetImagesAirlineCompany(int id);
    BaseDto AddAirlineCompany(AddAirlineCompanyDto model);
    int CheckLogo(int id);
    PaginatedItemsDto<AirlineCompanyListDto> GetAirlineCompanyList(string searchKey, int pageIndex, int pageSize);
    BaseDto DeleteAirlineCompany(int id);
    BaseDto<EditAirlineCompanyDto> FindAirlineCompany(int id);
    BaseDto EditAirlineCompany(EditAirlineCompanyDto model);
    BaseDto AddFlight(AddFlightDto model);
    PaginatedItemsDto<FlightListDto> GetFlightsList(int airlineCompanyId, string searchKey, int pageIndex, int pageSize);
    BaseDto<string> FindAirlineCompanyName(int id);
    InformationForAddFlightDto GetInformation();
    BaseDto<EditFlightDto> FindFlight(int id);
    BaseDto EditFlight(EditFlightDto model);
    BaseDto DeleteFlight(int id);
}

public class FlightService : IFlightService
{
    private readonly IDatabaseContext _databaseContext;

    public FlightService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public BaseDto AddAirlineCompany(AddAirlineCompanyDto model)
    {
        var airlineCompany = new AirlineCompany
        {
            Name = model.Name,
            Description = model.Description,
            Address = model.Address,
            PhoneNumber = model.PhoneNumber,
            Website = model.Website
        };
        _databaseContext.AirlineCompanies.Add(airlineCompany);
        _databaseContext.SaveChanges();
        var logo = new Image
        {
            Src = model.ImageSrc,
            AirlineCompanyId = airlineCompany.Id,
        };
        _databaseContext.Images.Add(logo);
        _databaseContext.SaveChanges();


        return new BaseDto
        {
            IsSuccess = true,
            Message = "شرکت هواپیمایی با موفقیت ثبت شد !"
        };
    }

    public PaginatedItemsDto<AirlineCompanyListDto> GetAirlineCompanyList(string searchKey, int pageIndex, int pageSize)
    {
        var rowCount = 0;
        var airlineCompanies = _databaseContext.AirlineCompanies
            .Include(x => x.Flights)
            .Include(x => x.Image)
            .ToPaged(pageIndex, pageSize, out rowCount)
            .OrderByDescending(x => x.Id)
            .Select(x => new AirlineCompanyListDto
            {
                Id = x.Id,
                Address = x.Address,
                Name = x.Name,
                Description = x.Description,
                PhoneNumber = x.PhoneNumber,
                Website = x.Website,
                ImageSrc = x.Image.Src
            }).AsQueryable();


        if (searchKey != null)
        {
            airlineCompanies = airlineCompanies.Where(x => x.Name.Contains(searchKey) || x.Address.Contains(searchKey));
        }

        return new PaginatedItemsDto<AirlineCompanyListDto>(pageIndex, pageSize, rowCount, airlineCompanies.ToList());
    }

    public BaseDto DeleteAirlineCompany(int id)
    {
        var airlineCompany = _databaseContext.AirlineCompanies.Find(id);
        if (airlineCompany == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "شرکت هواپیمایی پیدا نشد !"
            };
        _databaseContext.AirlineCompanies.Remove(airlineCompany);
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "عملیات موفقیت آمیز !"
        };
    }

    public BaseDto<EditAirlineCompanyDto> FindAirlineCompany(int id)
    {
        var airlineCompany = _databaseContext.AirlineCompanies.Include(x => x.Image)
            .Select(x => new EditAirlineCompanyDto
            {
                Id = x.Id,
                Address = x.Address,
                Description = x.Description,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Website = x.Website,
                ImageSrc = x.Image.Src
            }).FirstOrDefault(x => x.Id == id);

        if (airlineCompany == null)
            return new BaseDto<EditAirlineCompanyDto>
            {
                IsSuccess = false,
                Message = "شرکت هواپیمایی پیدا نشد !"
            };

        return new BaseDto<EditAirlineCompanyDto>
        {
            Data = airlineCompany,
            IsSuccess = true
        };
    }

    public BaseDto EditAirlineCompany(EditAirlineCompanyDto model)
    {
        var airlineCompany = _databaseContext.AirlineCompanies
            .Include(x => x.Image)
            .FirstOrDefault(x => x.Id == model.Id);
        if (airlineCompany == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "شرکت هواپیمایی پیدا نشد !"
            };
        airlineCompany.Name = model.Name;
        airlineCompany.Description = model.Description;
        airlineCompany.Address = model.Address;
        airlineCompany.PhoneNumber = model.PhoneNumber;
        airlineCompany.Website = model.Website;
        if (model.Logo != null && model.Logo.Length > 0)
        {
            var logo = new Image
            {
                Src = model.ImageSrc,
                AirlineCompanyId = airlineCompany.Id,
            };
            _databaseContext.Images.Add(logo);
        }
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "موفقیت آمیز !"
        };

    }

    public BaseDto AddFlight(AddFlightDto model)
    {
        var flight = new Flight
        {
            AirportOrigin = model.AirportOrigin,
            AirportDestination = model.AirportDestination,
            AirlineCompanyId = model.AirlineCompanyId,
            BasePrice = model.BasePrice,
            CancellationCharge = model.CancellationPrice,
            FlightType = model.FlightType,
            FlyingTo = model.FlyingTo,
            LandingDate = model.LandingDate.ToGeorgianDateTime(),
            Coach = model.Coach,
            Refundable = model.Refundable,
            SeatNumber = model.SeatNumber,
            TakeOffDate = SetTime(model.TakeOffTime, model.TakeOffDate.ToGeorgianDateTime()),
            PriceRange = model.PriceRange,
            TaxesAndFees = model.TaxesAndFees,
            FlyingFrom = model.FlyingFrom,
            Description = model.Description,
            CurrencyId = model.CurrencyValue,
            Slug = model.Slug,
            TotalTimeOfFlight = model.TotalTimeOfFlight,
            ReturnLandingDate = model.ReturnLandingDate.ToGeorgianDateTime(),
            ReturnTakeOffDate = SetTime(model.ReturnTakeOffTime, model.ReturnTakeOffDate.ToGeorgianDateTime()),
        };
        _databaseContext.Flights.Add(flight);
        _databaseContext.SaveChanges();
        var amenityIds = model.AmenitiesValue.Keys.ToList();
        foreach (var item in amenityIds)
        {
            _databaseContext.AmenityFlights.Add(new AmenityFlight
            {
                FlightId = flight.Id,
                AmenityId = item
            });
        }
        _databaseContext.SaveChanges();
        if (model.ImagesSrc != null && model.ImagesSrc.Count > 0)
        {
            flight.Images = new List<Image>();
            foreach (var src in model.ImagesSrc)
            {
                flight.Images.Add(new Image
                {
                    FlightId = flight.Id,
                    Src = src,
                });
            }
        }
        _databaseContext.SaveChanges();

        return new BaseDto
        {
            IsSuccess = true
        };
    }

    public PaginatedItemsDto<FlightListDto> GetFlightsList(int airlineCompanyId, string searchKey, int pageIndex, int pageSize)
    {
        var rowCount = 0;
        var list = _databaseContext.Flights.Where(x => x.AirlineCompanyId == airlineCompanyId)
            .Include(x => x.Seats)
            .Include(x => x.Discounts)
            .ToPaged(pageIndex, pageSize, out rowCount)
            .Select(x => new FlightListDto
            {
                Id = x.Id,
                TakeOffDate = x.TakeOffDate.ToFarsi() ?? "",
                ReturnTakeOffDate = x.ReturnTakeOffDate.ToFarsi() ?? "",
                AirportOrigin = x.AirportOrigin,
                AirportDestination = x.AirportDestination,
                FlyingFrom = x.FlyingFrom,
                FlyingTo = x.FlyingTo,
                AvailableSeats = x.SeatNumber,
                DiscountPercent = x.Discounts.Where(x => x.EndDate > DateTime.Now).Select(x => x.Percent).FirstOrDefault(),
                DiscountId = x.Discounts.Where(x => x.EndDate > DateTime.Now).Select(x => x.Id).FirstOrDefault(),
                FlightType = x.FlightType,

            });

        if (searchKey != null)
        {
            list = list.Where(x => x.FlyingFrom.Contains(searchKey) || x.FlyingTo.Contains(searchKey) || x.AirportOrigin.Contains(searchKey));
        }

        return new PaginatedItemsDto<FlightListDto>(pageIndex, pageSize, rowCount, list.ToList());
    }

    public BaseDto<string> FindAirlineCompanyName(int id)
    {
        var result = _databaseContext.AirlineCompanies
            .Select(x => new { x.Name, x.Id }).FirstOrDefault(x => x.Id == id);

        if (result == null)
            return new BaseDto<string>
            {
                IsSuccess = false,
                Message = "شرکت هواپیمایی پیدا نشد !"
            };

        return new BaseDto<string>
        {
            Data = result.Name,
            IsSuccess = true
        };



    }

    public InformationForAddFlightDto GetInformation()
    {
        return new InformationForAddFlightDto
        {
            Amenities = _databaseContext.Amenities.Where(x => x.AmenityType == AmenityType.Flight)
                .Select(x => new AmenityDto
                {
                    Display = x.Display,
                    Title = x.Title,
                    Id = x.Id
                }).ToList(),
            Currencies = _databaseContext.Currencies.Select(x => new CurrencyDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList()
        };
    }

    private DateTime SetTime(string time, DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3)), 0);
    }
    public BaseDto<EditFlightDto> FindFlight(int id)
    {
        var flight = _databaseContext.Flights
            .Include(x => x.Images)
            .Include(x => x.AmenityFlights)
            .ThenInclude(x => x.Amenity)
            .Include(x => x.Currency)
            .Include(x => x.AirlineCompany)
            .Select(x => new EditFlightDto
            {
                AirlineCompanyId = x.AirlineCompanyId,
                AirportOrigin = x.AirportOrigin,
                AirportDestination = x.AirportDestination,
                CurrencyValue = x.CurrencyId,
                BasePrice = x.BasePrice,
                Coach = x.Coach,
                Description = x.Description,
                FlightType = x.FlightType,
                FlyingFrom = x.FlyingFrom,
                FlyingTo = x.FlyingTo,
                Id = x.Id,
                CancellationPrice = x.CancellationCharge,
                LandingDate = x.LandingDate.ToShamsi(),
                PriceRange = x.PriceRange,
                Refundable = x.Refundable,
                ReturnLandingDate = x.ReturnLandingDate.ToShamsi(),
                ReturnTakeOffDate = x.ReturnTakeOffDate.ToShamsi(),
                SeatNumber = x.SeatNumber,
                TakeOffDate = x.TakeOffDate.ToShamsi(),
                ReturnTakeOffTime = $"{x.ReturnTakeOffDate.Hour}:{x.ReturnTakeOffDate.Minute}",
                TakeOffTime = $"{x.TakeOffDate.Hour}:{x.TakeOffDate.Minute}",
                TaxesAndFees = x.TaxesAndFees,
                TotalTimeOfFlight = x.TotalTimeOfFlight,
                Slug = x.Slug,
                ImagesSrc = x.Images.Select(x => x.Src).ToList(),
                AmenitiesValue = GetAmenities(x.AmenityFlights.Where(x => x.Amenity.AmenityType == AmenityType.Flight).Select(x => x.Amenity.Id).ToList()),
            }).FirstOrDefault(x => x.Id == id);

        if (flight == null)
            return new BaseDto<EditFlightDto>
            {
                IsSuccess = false
            };

        return new BaseDto<EditFlightDto>
        {
            IsSuccess = true,
            Data = flight,
        };

    }
    private static Dictionary<int, string> GetAmenities(List<int> ids)
    {
        var amenities = new Dictionary<int, string>();

        foreach (var id in ids)
        {
            amenities.Add(id, "on");
        }

        return amenities;
    }

    public BaseDto EditFlight(EditFlightDto model)
    {
        var flight = _databaseContext.Flights
            .Include(x => x.Images)
            .Include(x => x.AmenityFlights)
            .ThenInclude(x => x.Amenity)
            .Include(x => x.Currency)
            .Include(x => x.AirlineCompany)
            .FirstOrDefault(x => x.Id == model.Id);

        if (flight == null)
            return new BaseDto
            {
                IsSuccess = false
            };

        flight.AirportDestination = model.AirportDestination;
        flight.AirportOrigin = model.AirportOrigin;
        flight.BasePrice = model.BasePrice;
        flight.CancellationCharge = model.CancellationPrice;
        flight.Coach = model.Coach;
        flight.CurrencyId = model.CurrencyValue;
        flight.Description = model.Description;
        flight.FlightType = model.FlightType;
        flight.FlyingFrom = model.FlyingFrom;
        flight.FlyingTo = model.FlyingTo;
        flight.LandingDate = model.LandingDate.ToGeorgianDateTime();
        flight.PriceRange = model.PriceRange;
        flight.Refundable = model.Refundable;
        flight.ReturnLandingDate = model.ReturnLandingDate.ToGeorgianDateTime();
        flight.ReturnTakeOffDate = SetTime(model.ReturnTakeOffTime, model.ReturnTakeOffDate.ToGeorgianDateTime());
        flight.SeatNumber = model.SeatNumber;
        flight.TotalTimeOfFlight = model.TotalTimeOfFlight;
        flight.TaxesAndFees = model.TaxesAndFees;
        flight.TakeOffDate = SetTime(model.TakeOffTime, model.TakeOffDate.ToGeorgianDateTime());
        flight.Slug = model.Slug;
        var amenitiesFlight = _databaseContext.AmenityFlights
                    .Where(x => x.FlightId == model.Id).ToList();
        _databaseContext.AmenityFlights.RemoveRange(amenitiesFlight);
        _databaseContext.SaveChanges();
        foreach (var dic in model.AmenitiesValue.Keys)
        {
            flight.AmenityFlights.Add(new AmenityFlight
            {
                AmenityId = dic,
                FlightId = model.Id
            });
        }
        if (model.ImagesSrc != null && model.ImagesSrc.Count > 0)
        {
            foreach (var src in model.ImagesSrc)
            {
                flight.Images.Add(new Image
                {
                    FlightId = model.Id,
                    Src = src,
                });
            }
        }
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true
        };
    }

    public BaseDto DeleteFlight(int id)
    {
        var flight = _databaseContext.Flights.Find(id);
        if (flight == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "عملیات نا موفق !"
            };
        _databaseContext.Flights.Remove(flight);
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "پرواز با موفقیت حذف شد !"
        };
    }

    public List<ImageDto> GetImages(int id)
    {
        return _databaseContext.Images.Where(x => x.FlightId == id).Select(x => new ImageDto
        {
            Id = x.Id,
            Src = x.Src
        }).ToList();

    }

    public List<ImageDto> GetImagesAirlineCompany(int id)
    {
        return _databaseContext.Images.Where(x => x.AirlineCompanyId == id).Select(x => new ImageDto
        {
            Id = x.Id,
            Src = x.Src
        }).ToList();
    }

    public int CheckLogo(int id)
    {
        var logo = _databaseContext.Images.FirstOrDefault(x => x.AirlineCompanyId == id);
        if (logo == null)
            return 0;
        return logo.Id;

    }
}