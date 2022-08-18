using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Common;
using T.Domain.Comments;
using T.Domain.Common;
using T.Domain.Hotels;
using T.Persistence.Contexts.SqlServerDb;
using T.Website.Endpoint.Models;
using T.Website.Endpoint.Models.Comments;
using T.Website.Endpoint.Models.Hotel;

namespace T.Website.Endpoint.Services;

public interface IHotelServiceUI
{
    PaginatedItemsDto<HotelListViewModel> Search(SearchHotel model, int pageIndex, int pageSize);
    BaseDto<HotelDetailViewModel> GetDetails(string slug);
    PaginatedItemsDto<RoomListViewModel> GetRoomsList(string hotelSlug, int page, int pageSize);
    BaseDto<string> GetHotelName(string slug);
    BaseDto<RoomDetails> GetRoomDetails(string roomSlug);

}

public class HotelServiceUI : IHotelServiceUI
{
    private readonly IDatabaseContext _databaseContext;

    public HotelServiceUI(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    private bool IsAmenitiesExist(List<int> amenitiesId, Dictionary<int, string> amenitiesModel)
    {
        var values = new List<bool>();
        var amenitiesKey = amenitiesModel.Keys.ToList();
        foreach (var item in amenitiesKey)
        {
            if (amenitiesId.Contains(item))
            {
                values.Add(true);
            }
            else
            {
                values.Add(false);
            }
        }

        var trues = values.Where(x => x == true).Count();
        if (trues == amenitiesKey.Count())
            return true;

        return false;



    }

    private bool IsBedNumberExist(List<int> bedsCount, int model)
    {
        if (model != 0)
        {
            if (bedsCount.Any(x => x == model))
                return true;
            return false;
        }
        return false;
    }

    public PaginatedItemsDto<HotelListViewModel> Search(SearchHotel model, int pageIndex, int pageSize)
    {
        var rowCount = 0;
        var hotelList = _databaseContext.Hotels
            .Include(x => x.Images)
            .Include(x => x.Rooms)
            .Include(x => x.AmenityHotels).ThenInclude(x => x.Amenity)
            .ToPaged(pageIndex, pageSize, out rowCount)
            .Select(x => new HotelListViewModel
            {
                Address = x.City + " - " + x.Address,
                ImageSrc = ComposeImageUri(x.Images.Select(x => x.Src).FirstOrDefault() ?? ""),
                Name = x.Name,
                CommentCount = 24,
                UserRate = 4.2,
                BedNumbers = x.Rooms.Select(x => x.BedCount).ToList(),
                StarCount = x.StarsCount,
                HighestPrice = x.MaximumRoomPrice,
                City = x.City,
                LowestPrice = x.MaximumRoomPrice,
                Amenities = x.AmenityHotels.Select(x => x.Amenity.Id).ToList(),
                IsAmenitiesExist = IsAmenitiesExist(x.AmenityHotels.Select(x => x.Amenity.Id).ToList(), model.AmenitiesValue ?? new Dictionary<int, string>()),
                IsBedNumberExist = IsBedNumberExist(x.Rooms.Select(x => x.BedCount).ToList(), (int)model.BedNumber),
                Slug = x.Slug
            }).AsQueryable();

        if (model.StarNumber != 0)
            hotelList = hotelList.Where(x => x.StarCount == model.StarNumber);

        if (model.LowestPrice != null && model.HighestPrice != null)
        {
            hotelList = hotelList.Where(x => x.LowestPrice <= int.Parse(model.LowestPrice)
                                    && x.HighestPrice >= int.Parse(model.HighestPrice));
        }

        if (model.City != null)
            hotelList = hotelList.Where(x => x.City.Contains(model.City));

        if (model.AmenitiesValue != null && model.AmenitiesValue.Count() != 0)
            hotelList = hotelList.Where(x => x.IsAmenitiesExist);

        if (model.BedNumber != 0)
            hotelList = hotelList.Where(x => x.IsBedNumberExist);

        var list = hotelList.OrderByDescending(x => x.Id).ToList();


        return new PaginatedItemsDto<HotelListViewModel>(pageIndex, pageSize, rowCount, list);
    }

    private static string ComposeImageUri(string imageSrc)
    {
        return "https://localhost:7235/" + imageSrc.Replace("\\", "//");
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

    public BaseDto<HotelDetailViewModel> GetDetails(string slug)
    {
        var hotel = _databaseContext.Hotels
            .Include(x => x.AmenityHotels).ThenInclude(x => x.Amenity)
            .Include(x => x.Country)
            .Include(x => x.Images)
            .Include(x => x.Rooms)
            .Include(x => x.Comments)
            .Select(x => new HotelDetailViewModel
            {
                Address = $"{x.City} - {x.Address}",
                City = x.City,
                Country = x.Country.Name,
                Id = x.Id,
                Name = x.Name,
                StarCount = x.StarsCount,
                Cancellation = x.Cancellation,
                Description = x.Description ?? string.Empty,
                ExtraPeople = x.ExtraPeople,
                HotelImagesSrc = ComposeImagesUri(x.Images.Where(y => y.HotelId == x.Id).Select(y => y.Src).Skip(1).ToList()),
                Amenities = x.AmenityHotels.Select(x => x.Amenity.Title).ToList(),
                ImageSrc = ComposeImageUri(x.Images.Where(y => y.HotelId == x.Id).Select(y => y.Src).FirstOrDefault() ?? ""),
                Slug = x.Slug,
                LowestPrice = x.Rooms.Select(x => x.Price).MinOrDefault(-1).ToString("n0")
            }).FirstOrDefault(x => x.Slug == slug);
        if (hotel == null)
            return new BaseDto<HotelDetailViewModel>
            {
                IsSuccess = false
            };

        hotel.Comments = _databaseContext.Comments
            .Where(x => x.HotelId == hotel.Id)
            .Select(x => new CommentViewModel
            {
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Rate = x.ServiceRate,
                Date = EF.Property<DateTime>(x, "InsertDate").ToFarsi()
            }).ToList();

        hotel.Rooms = _databaseContext.Rooms
                .Include(x => x.AmenityRooms).ThenInclude(x => x.Amenity)
                .Include(x => x.Images)
                .Select(x => new HotelDetailRoomListViewModel
                {
                    Price = x.Price.ToString("n0"),
                    Name = x.Name,
                    ImageSrc = ComposeImageUri(x.Images.Where(y => y.RoomId == x.Id).Select(x => x.Src).FirstOrDefault() ?? ""),
                    Id = x.Id,
                    Amenities = x.AmenityRooms.Select(x => x.Amenity.Title).ToList(),
                    Slug = x.Slug
                }).Take(3).ToList();

        return new BaseDto<HotelDetailViewModel>
        {
            Data = hotel,
            IsSuccess = true
        };


    }

    public PaginatedItemsDto<RoomListViewModel> GetRoomsList(string hotelSlug, int page, int pageSize)
    {
        var rowCount = 0;
        var rooms = _databaseContext.Rooms
            .Include(x => x.Hotel)
            .Include(x => x.AmenityRooms).ThenInclude(x => x.Amenity)
            .Include(x => x.Images)
            .ToPaged(page, pageSize, out rowCount)
            .Select(x => new RoomListViewModel
            {
                Id = x.Id,
                BedCount = x.BedCount,
                ImagesSrc = ComposeImagesUri(x.Images.Where(y => y.RoomId == x.Id).Take(3).Select(x => x.Src).ToList()),
                Name = x.Name,
                Price = x.Price.ToString("n0"),
                Size = x.Size,
                Amenities = x.AmenityRooms.Select(x => x.Amenity.Title).ToList(),
                HotelSlug = x.Hotel.Slug,
                RoomSlug = x.Slug,
                Description = x.Description
            }).Where(x => x.HotelSlug == hotelSlug).ToList();

        return new PaginatedItemsDto<RoomListViewModel>(page, pageSize, rowCount, rooms);
    }

    public BaseDto<string> GetHotelName(string slug)
    {
        var hotel = _databaseContext.Hotels
                    .Select(x => new { x.Slug, x.Name }).FirstOrDefault(x => x.Slug == slug);

        if (hotel == null)
            return new BaseDto<string>
            {
                IsSuccess = false
            };

        return new BaseDto<string>
        {
            Data = hotel.Name,
            IsSuccess = true
        };
    }

    public BaseDto<RoomDetails> GetRoomDetails(string roomSlug)
    {
        var room = _databaseContext.Rooms
            .Include(x => x.AmenityRooms).ThenInclude(x => x.Amenity)
            .Include(x => x.Hotel)
            .Include(x => x.Images)
            .Include(x => x.Discounts)
            .Select(x => new RoomDetails
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                CommentCount = 29,
                UserRate = 4.6,
                Services = x.AmenityRooms.Where(x => x.Amenity.AmenityType == AmenityType.RoomService).Select(x => x.Amenity.Title).ToList(),
                Description = x.Description,
                Amenities = x.AmenityRooms.Where(x => x.Amenity.AmenityType == AmenityType.Room).Select(x => x.Amenity.Title).ToList(),
                ImagesSrc = ComposeImagesUri(x.Images.Where(y => y.RoomId == x.Id).Select(x => x.Src).ToList()),
                Price = x.Price,
                Discounts = x.Discounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => x.Percent).ToList(),
                Count = x.Count
            }).FirstOrDefault(x => x.Slug == roomSlug);

        // (((100 - x.Discounts.Select(x => x.Percent).FirstOrDefault()) / 100) * (x.Price)).ToString("n0")
        if (room == null)
            return new BaseDto<RoomDetails>
            {
                IsSuccess = false
            };

        if (room.Discounts.Count() > 0)
        {
            var discount = room.Discounts.LastOrDefault();
            room.PriceWithDiscount = (((100 - discount) * 0.01) * (room.Price)).ToString("n0");

        }
        return new BaseDto<RoomDetails>
        {
            Data = room,
            IsSuccess = true
        };
    }
}
