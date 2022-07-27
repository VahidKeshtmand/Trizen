using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Dtos.Hotels;
using T.Domain.Common;
using T.Domain.Hotels;

namespace T.Application.Services.Hotels
{
    public interface IHotelService
    {
        List<RequestHotelsListDto> GetRequestList();
        List<JobTitleDto> GetJobsTitleList();
        List<CountryNameDto> GetCountriesNameList();
        List<CountryCodeDto> GetCountriesCodeList();
        List<CurrencyDto> GetCurrenciesList();
        List<AmenityDto> GetAmenitiesList();
        BaseDto Register(RegisterHotelDto model);
    }

    public class HotelService : IHotelService
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HotelService(IDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public List<JobTitleDto> GetJobsTitleList()
        {
            return _databaseContext.JobTitles.Select(x => new JobTitleDto
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }

        public List<CountryNameDto> GetCountriesNameList()
        {
            return _databaseContext.Countries.Select(x => new CountryNameDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<CountryCodeDto> GetCountriesCodeList()
        {
            return _databaseContext.Countries.Select(x => new CountryCodeDto
            {
                Id = x.Id,
                Code = $"{x.Name} ({x.Code})"
            }).ToList();
        }

        public List<CurrencyDto> GetCurrenciesList()
        {
            return _databaseContext.Currencies.Select(x => new CurrencyDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<AmenityDto> GetAmenitiesList()
        {
            return _databaseContext.Amenities.Select(x => new AmenityDto
            {
                Id = x.Id,
                Title = x.Title,
                Display = x.Display
            }).ToList();
        }

        public BaseDto Register(RegisterHotelDto model)
        {

            var contact = new Contact
            {
                Email = model.Email,
                Facebook = model.Email,
                PhoneNumber = model.PhoneNumber,
                Linkedin = model.Linkedin,
                Twitter = model.Twitter,
                Website = model.Website,
            };
            _databaseContext.Contacts.Add(contact);
            _databaseContext.SaveChanges();
            var personalInformation = new PersonalInformation
            {
                Email = model.Email,
                JobTitleId = model.PersonalJobTitle,
                Name = model.Name,
            };
            _databaseContext.PersonalInformations.Add(personalInformation);
            _databaseContext.SaveChanges();
            var hotel = new Hotel
            {
                Address = model.Address,
                Bathroom = model.BathroomValue,
                City = model.City,
                Description = model.Description,
                MaximumRoomPrice = model.MaximumRoomPrice,
                MinimumRoomPrice = model.MinimumRoomPrice,
                MinimumDaysStay = model.MinimumDaysStayValue,
                Name = model.Name,
                Housekeeping = model.HousekeepingValue,
                HousekeepingFrequency = model.HousekeepingFrequencyValue,
                RoomsCount = model.RoomsCount,
                CurrencyId = model.Currency,
                CountryId = model.Country,
                ContactId = contact.Id,
                PersonalInformationId = personalInformation.Id
            };
            _databaseContext.Hotels.Add(hotel);
            _databaseContext.SaveChanges();
            var amenityIds = model.AmenitiesValue.Keys.ToList();
            foreach (var item in amenityIds)
            {
                _databaseContext.AmenityHotels.Add(new AmenityHotel
                {
                    HotelId = hotel.Id,
                    AmenityId = item
                });
            }
            _databaseContext.SaveChanges();
            return new BaseDto
            {
                IsSuccess = true,
                Message = "با موفقیت ارسال شد. بعد از بررسی با شما تماس می گیریم."
            };
        }

        public List<RequestHotelsListDto> GetRequestList()
        {
            return _databaseContext.Hotels
            .Include(x => x.Contact)
            .Include(x => x.Country)
            .Select(x => new RequestHotelsListDto
            {
                Name = x.Name,
                PhoneNumber = x.Contact.PhoneNumber,
                Location = x.Country.Name + x.City,
                Website = x.Contact.Website
            }).ToList();

        }
    }
}
