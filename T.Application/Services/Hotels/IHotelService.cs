using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Dtos.Hotels;
using T.Common;
using T.Domain.Common;
using T.Domain.Hotels;


namespace T.Application.Services.Hotels
{
    public interface IHotelService
    {
        PaginatedItemsDto<ListDto> GetList(int page, int pageSize);
        List<ImageDto> GetImages(int id);
        InformationDto GetInformation();
        BaseDto Register(RegisterDto model);
        DetailDto GetDetail(int id);
        bool Remove(int id);
        EditDto GetHotel(int id);
        BaseDto Edit(EditDto model);

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

        public InformationDto GetInformation()
        {
            var countriesName = _databaseContext.Countries.Select(x => new CountryNameDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var countriesCode = _databaseContext.Countries.Select(x => new CountryCodeDto
            {
                Id = x.Id,
                Code = $"{x.Name} ({x.Code})"
            }).ToList();
            var currencies = _databaseContext.Currencies.Select(x => new CurrencyDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var amenities = _databaseContext.Amenities.Where(x => x.AmenityType == AmenityType.Hotel).Select(x => new AmenityDto
            {
                Id = x.Id,
                Title = x.Title,
                Display = x.Display
            }).ToList();

            return new InformationDto
            {
                Amenities = amenities,
                CountriesCode = countriesCode,
                CountriesName = countriesName,
                Currencies = currencies,
            };

        }

        public BaseDto Register(RegisterDto model)
        {
            var contact = new Contact
            {
                Email = model.Email,
                Facebook = model.Facebook,
                PhoneNumber = model.PhoneNumber,
                Linkedin = model.Linkedin,
                Twitter = model.Twitter,
                Website = model.Website,
            };
            _databaseContext.Contacts.Add(contact);
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
                StarsCount = model.StarsCount,
                Cancellation = model.Cancellation,
                ExtraPeople = model.ExtraPeople,
                Slug = model.Slug
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
            if (model.ImagesSrc != null && model.ImagesSrc.Count > 0)
            {
                hotel.Images = new List<Image>();
                foreach (var src in model.ImagesSrc)
                {
                    hotel.Images.Add(new Image
                    {
                        HotelId = hotel.Id,
                        Src = src,
                    });
                }
            }
            _databaseContext.SaveChanges();
            return new BaseDto
            {
                IsSuccess = true,
                Message = ""
            };
        }

        public DetailDto GetDetail(int id)
        {
            var hotel = _databaseContext.Hotels
                .Include(x => x.AmenityHotels)
                .ThenInclude(x => x.Amenity)
                .Include(x => x.Country)
                .Include(x => x.Currency)
                .Include(x => x.Contact)
                .Include(x => x.Images)
                .Select(x => new DetailDto
                {
                    Id = x.Id,
                    Address = x.Address,
                    Bathroom = x.Bathroom,
                    City = x.City,
                    Country = x.Country.Name,
                    CountryCode = x.Country.Code,
                    Description = x.Description,
                    Currency = x.Currency.Name,
                    Email = x.Contact.Email,
                    Facebook = x.Contact.Facebook,
                    Linkedin = x.Contact.Linkedin,
                    Twitter = x.Contact.Twitter,
                    Website = x.Contact.Website,
                    HousekeepingFrequencyValue = x.HousekeepingFrequency,
                    HousekeepingValue = x.Housekeeping,
                    MaximumRoomPrice = x.MaximumRoomPrice,
                    MinimumDaysStayValue = x.MinimumDaysStay,
                    MinimumRoomPrice = x.MinimumRoomPrice,
                    Name = x.Name,
                    RoomsCount = x.RoomsCount,
                    PhoneNumber = x.Contact.PhoneNumber,
                    Amenities = x.AmenityHotels.Select(x => x.Amenity.Title).ToList(),
                    ImagesSrc = ComposeImageUri(x.Images.Select(x => x.Src).ToList())
                }).FirstOrDefault(x => x.Id == id);

            if (hotel == null) return new DetailDto();

            return hotel;
        }
        private static List<string> ComposeImageUri(List<string> imagesSrc)
        {
            var srcs = new List<string>();
            foreach (var src in imagesSrc)
            {
                srcs.Add("https://localhost:7235/" + src.Replace("\\", "//"));
            }

            return srcs;
        }

        public PaginatedItemsDto<ListDto> GetList(int page, int pageSize)
        {
            int rowCount = 0;
            var hotels = _databaseContext.Hotels
                .Include(x => x.Contact)
                .Include(x => x.Country)
                .ToPaged(page, pageSize, out rowCount)
                .OrderByDescending(x => x.Id)
                .Select(x => new ListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhoneNumber = x.Contact.PhoneNumber,
                    Location = x.Country.Name + " - " + x.City,
                    Website = x.Contact.Website,

                }).ToList();

            return new PaginatedItemsDto<ListDto>(page, pageSize, rowCount, hotels);
        }

        public bool Remove(int id)
        {
            var hotel = _databaseContext.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null)
                return false;
            _databaseContext.Hotels.Remove(hotel);
            _databaseContext.SaveChanges();
            return true;
        }

        public EditDto GetHotel(int id)
        {
            var hotel = _databaseContext.Hotels
                .Include(x => x.AmenityHotels)
                .ThenInclude(x => x.Amenity)
                .Include(x => x.Country)
                .Include(x => x.Currency)
                .Include(x => x.Contact)
                .Include(x => x.Images)
                .Select(x => new EditDto
                {
                    Id = x.Id,
                    Address = x.Address,
                    BathroomValue = x.Bathroom,
                    City = x.City,
                    Country = x.Country.Id,
                    CountryCode = x.Country.Id,
                    Description = x.Description,
                    Currency = x.Currency.Id,
                    Email = x.Contact.Email,
                    Facebook = x.Contact.Facebook,
                    Linkedin = x.Contact.Linkedin,
                    Twitter = x.Contact.Twitter,
                    Website = x.Contact.Website,
                    HousekeepingFrequencyValue = x.HousekeepingFrequency,
                    HousekeepingValue = x.Housekeeping,
                    MaximumRoomPrice = x.MaximumRoomPrice,
                    MinimumDaysStayValue = x.MinimumDaysStay,
                    MinimumRoomPrice = x.MinimumRoomPrice,
                    Name = x.Name,
                    RoomsCount = x.RoomsCount,
                    PhoneNumber = x.Contact.PhoneNumber,
                    AmenitiesValue = GetAmenities(x.AmenityHotels.Select(x => x.Amenity.Id).ToList()),
                    Cancellation = x.Cancellation,
                    ExtraPeople = x.ExtraPeople,
                    StarsCount = x.StarsCount,
                    ImagesSrc = x.Images.Select(x => x.Src).ToList(),
                    Slug = x.Slug
                }).FirstOrDefault(x => x.Id == id);

            if (hotel == null) return new EditDto();

            return hotel;
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

        public BaseDto Edit(EditDto model)
        {
            var hotel = _databaseContext.Hotels
                .Include(x => x.AmenityHotels)
                .ThenInclude(x => x.Amenity)
                .Include(x => x.Country)
                .Include(x => x.Currency)
                .Include(x => x.Contact)
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == model.Id);
            if (hotel == null) return new BaseDto { IsSuccess = false, Message = "هتل مورد نظر یافت نشد !" };

            hotel.Address = model.Address;
            hotel.Bathroom = model.BathroomValue;
            hotel.Cancellation = model.Cancellation;
            hotel.City = model.City;
            hotel.Contact.Email = model.Email;
            hotel.Contact.Website = model.Website;
            hotel.Contact.Facebook = model.Facebook;
            hotel.Contact.Twitter = model.Twitter;
            hotel.Contact.Linkedin = model.Linkedin;
            hotel.Contact.PhoneNumber = model.PhoneNumber;
            hotel.Bathroom = model.BathroomValue;
            hotel.CountryId = model.Country;
            hotel.CurrencyId = model.Currency;
            hotel.Description = model.Description;
            hotel.ExtraPeople = model.ExtraPeople;
            hotel.Description = model.Description;
            hotel.Cancellation = model.Cancellation;
            hotel.CurrencyId = model.Currency;
            hotel.Housekeeping = model.HousekeepingValue;
            hotel.HousekeepingFrequency = model.HousekeepingFrequencyValue;
            hotel.MaximumRoomPrice = model.MaximumRoomPrice;
            hotel.MinimumRoomPrice = model.MinimumRoomPrice;
            hotel.MinimumDaysStay = model.MinimumDaysStayValue;
            hotel.StarsCount = model.StarsCount;
            hotel.Name = model.Name;
            hotel.RoomsCount = model.RoomsCount;
            hotel.Slug = model.Slug;
            foreach (var dic in model.AmenitiesValue.Keys)
            {
                if (!_databaseContext.AmenityHotels.Where(x => x.HotelId == model.Id && x.AmenityId == dic).Any())
                {
                    hotel.AmenityHotels.Add(new AmenityHotel
                    {
                        AmenityId = dic,
                        HotelId = model.Id
                    });
                }

            }
            if (model.ImagesSrc != null && model.ImagesSrc.Count > 0)
            {
                foreach (var src in model.ImagesSrc)
                {
                    hotel.Images.Add(new Image
                    {
                        HotelId = model.Id,
                        Src = src,
                    });
                }
            }
            _databaseContext.SaveChanges();

            return new BaseDto
            {
                IsSuccess = true,
                Message = "مشخصات هتل ویرایش شد !"
            };

        }

        public List<ImageDto> GetImages(int id)
        {
            return _databaseContext.Images.Where(x => x.HotelId == id).Select(x => new ImageDto
            {
                Id = x.Id,
                Src = x.Src
            }).ToList();

        }


    }

}