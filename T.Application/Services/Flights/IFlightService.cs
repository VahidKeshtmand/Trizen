using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Dtos.Flights;
using T.Common;
using T.Domain.Common;
using T.Domain.Flight;

namespace T.Application.Services.Flights;

public interface IFlightService
{
    BaseDto AddAirlineCompany(AddAirlineCompanyDto model);
    PaginatedItemsDto<AirlineCompanyListDto> GetAirlineCompanyList(string searchKey, int pageIndex, int pageSize);
    BaseDto DeleteAirlineCompany(int id);
    BaseDto<EditAirlineCompanyDto> FindAirlineCompany(int id);
    BaseDto EditAirlineCompany(EditAirlineCompanyDto model);
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
                ImageSrc = ComposeImageUri(x.Image.Src)
            }).AsQueryable();


        if (searchKey != null)
        {
            airlineCompanies = airlineCompanies.Where(x => x.Name.Contains(searchKey) || x.Address.Contains(searchKey));
        }

        return new PaginatedItemsDto<AirlineCompanyListDto>(pageIndex, pageSize, rowCount, airlineCompanies.ToList());
    }

    private static string ComposeImageUri(string imageSrc)
    {
        return "https://localhost:7235/" + imageSrc.Replace("\\", "//");
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
                ImageSrc = ComposeImageUri(x.Image.Src)
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
        _databaseContext.Images.Remove(airlineCompany.Image);
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
            Message = "موفقیت آمیز !"
        };

    }
}