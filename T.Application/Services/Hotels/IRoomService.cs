using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Dtos.Rooms;
using T.Common;
using T.Domain.Common;
using T.Domain.Hotels;

namespace T.Application.Services.Hotels;

public interface IRoomService
{
    BaseDto<RoomIndexDto> GetList(int hotelId, int page, int pageSize);
    BaseDto<InformationRoomDto> GetInformation(int id);
    BaseDto Register(RegisterRoomDto model);
    List<string> GetImages(int id);
    BaseDto<RoomEditDto> GetRoom(int id);
    BaseDto Edit(RoomEditDto model);
    BaseDto Delete(int id);
    BaseDto<DetailRoomDto> GetDetail(int id);
}

public class RoomService : IRoomService
{
    private readonly IDatabaseContext _databaseContext;

    public RoomService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public BaseDto<RoomIndexDto> GetList(int hotelId, int page, int pageSize)
    {
        int rowCount = 0;
        var rooms = _databaseContext.Rooms
            .Include(x => x.Discounts)
            .Where(x => x.HotelId == hotelId)
            .ToPaged(page, pageSize, out rowCount)
            .OrderByDescending(x => x.Id)
            .Select(x => new RoomListDto
            {
                Id = x.Id,
                Name = x.Name,
                BedCount = x.BedCount,
                IsReserve = x.IsReserve,
                Price = x.Price,
                DiscountPercent = x.Discounts.Where(x => x.EndDate > DateTime.Now).Select(x => x.Percent).FirstOrDefault(),
                DiscountId = x.Discounts.Where(x => x.EndDate > DateTime.Now).Select(x => x.Id).FirstOrDefault(),
                Count = x.Count
            }).ToList();
        var hotel = _databaseContext.Hotels.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == hotelId);
        if (hotel == null)
            return new BaseDto<RoomIndexDto>
            {
                IsSuccess = false,
                Message = "هتل یافت نشد"
            };

        return new BaseDto<RoomIndexDto>
        {
            Data = new RoomIndexDto
            {
                RoomList = new PaginatedItemsDto<RoomListDto>(page, pageSize, rowCount, rooms),
                HotelId = hotel.Id,
                HotelName = hotel.Name ?? ""
            },
            IsSuccess = true,
            Message = ""
        };

    }

    public BaseDto<InformationRoomDto> GetInformation(int id)
    {
        var amenities = _databaseContext.Amenities.Where(x => x.AmenityType == AmenityType.Room)
            .Select(x => new AmenityDto
            {
                Display = x.Display,
                Id = x.Id,
                Title = x.Title
            }).ToList();
        var serviceAmenities = _databaseContext.Amenities.Where(x => x.AmenityType == AmenityType.RoomService)
            .Select(x => new AmenityDto
            {
                Display = x.Display,
                Id = x.Id,
                Title = x.Title
            }).ToList();
        var hotel = _databaseContext.Hotels.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == id);
        if (hotel == null || amenities == null || serviceAmenities == null)
            return new BaseDto<InformationRoomDto>
            {
                IsSuccess = false
            };
        return new BaseDto<InformationRoomDto>
        {
            Data = new InformationRoomDto
            {
                Amenities = amenities,
                ServiceAmenities = serviceAmenities,
                HotelName = hotel.Name,
                HotelId = hotel.Id
            },
            IsSuccess = true
        };



    }

    public BaseDto Register(RegisterRoomDto model)
    {
        var room = new Room
        {
            Name = model.Name,
            Description = model.Description,
            HotelId = model.HotelId,
            Price = model.Price,
            BedCount = model.BedCount,
            Size = model.Size,
            Slug = model.Slug
        };
        _databaseContext.Rooms.Add(room);
        _databaseContext.SaveChanges();
        var amenityIds = model.AmenitiesValue.Keys.ToList();
        foreach (var item in amenityIds)
        {
            _databaseContext.AmenityRooms.Add(new AmenityRoom
            {
                RoomId = room.Id,
                AmenityId = item
            });
        }
        var serviceAmenityIds = model.ServiceAmenitiesValue.Keys.ToList();
        foreach (var item in serviceAmenityIds)
        {
            _databaseContext.AmenityRooms.Add(new AmenityRoom
            {
                RoomId = room.Id,
                AmenityId = item,
            });
        }
        if (model.ImagesSrc != null && model.ImagesSrc.Count > 0)
        {
            room.Images = new List<Image>();
            foreach (var src in model.ImagesSrc)
            {
                room.Images.Add(new Image
                {
                    RoomId = room.Id,
                    Src = src
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

    public List<string> GetImages(int id)
    {
        var room = _databaseContext.Rooms.Include(x => x.Images)
            .Select(x => new { x.Id, x.Images }).FirstOrDefault(x => x.Id == id);

        if (room != null)
            return ComposeImageUri(room.Images.Select(x => x.Src).ToList());
        return new List<string>();

    }

    public static List<string> ComposeImageUri(List<string> imagesSrc)
    {
        var srcs = new List<string>();
        foreach (var src in imagesSrc)
        {
            srcs.Add("https://localhost:7235/" + src.Replace("\\", "//"));
        }

        return srcs;
    }

    public BaseDto<RoomEditDto> GetRoom(int id)
    {
        var room = _databaseContext.Rooms
        .Include(x => x.Hotel)
        .Include(x => x.AmenityRooms).ThenInclude(x => x.Amenity)
        .Include(x => x.Images)
        .Select(x => new RoomEditDto
        {
            Id = x.Id,
            BedCount = x.BedCount,
            Description = x.Description,
            Name = x.Name,
            Price = x.Price,
            Size = x.Size,
            HotelId = x.Hotel.Id,
            AmenitiesValue = GetAmenities(x.AmenityRooms
                .Where(x => x.Amenity.AmenityType == AmenityType.Room)
                .Select(x => x.Amenity.Id).ToList()),
            ImagesSrc = ComposeImageUri(x.Images.Select(x => x.Src).ToList()),
            ServiceAmenitiesValue = GetAmenities(x.AmenityRooms
                .Where(x => x.Amenity.AmenityType == AmenityType.RoomService)
                .Select(x => x.Amenity.Id).ToList())
        }).FirstOrDefault(x => x.Id == id);

        if (room == null)
            return new BaseDto<RoomEditDto>
            {
                IsSuccess = false
            };

        return new BaseDto<RoomEditDto>
        {
            IsSuccess = true,
            Data = room,
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

    public BaseDto Edit(RoomEditDto model)
    {
        var room = _databaseContext.Rooms
            .Include(x => x.Hotel)
            .Include(x => x.AmenityRooms).ThenInclude(x => x.Amenity)
            .Include(x => x.Images)
            .FirstOrDefault(x => x.Id == model.Id);
        if (room == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "اتاق پیدا نشد !"
            };

        room.Name = model.Name;
        room.Description = model.Description;
        room.BedCount = model.BedCount;
        room.Price = model.Price;
        room.Size = model.Price;
        var amenitiesRoom = _databaseContext.AmenityRooms
            .Where(x => x.RoomId == model.Id).ToList();
        _databaseContext.AmenityRooms.RemoveRange(amenitiesRoom);
        _databaseContext.SaveChanges();
        foreach (var dic in model.AmenitiesValue.Keys)
        {
            room.AmenityRooms.Add(new AmenityRoom
            {
                AmenityId = dic,
                RoomId = model.Id
            });
        }
        foreach (var dic in model.ServiceAmenitiesValue.Keys)
        {
            room.AmenityRooms.Add(new AmenityRoom
            {
                AmenityId = dic,
                RoomId = model.Id,
            });

        }
        if (model.ImagesSrc != null && model.ImagesSrc.Count > 0)
        {
            foreach (var src in model.ImagesSrc)
            {
                room.Images.Add(new Image
                {
                    RoomId = model.Id,
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

    public BaseDto Delete(int id)
    {
        var room = _databaseContext.Rooms.FirstOrDefault(x => x.Id == id);
        if (room == null)
            return new BaseDto
            {
                IsSuccess = false
            };
        _databaseContext.Rooms.Remove(room);
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true
        };
    }

    public BaseDto<DetailRoomDto> GetDetail(int id)
    {
        var room = _databaseContext.Rooms
            .Include(x => x.Hotel)
            .Include(x => x.AmenityRooms).ThenInclude(x => x.Amenity)
            .Include(x => x.Images)
            .Select(x => new DetailRoomDto
            {
                Id = x.Id,
                BedCount = x.BedCount,
                Description = x.Description,
                HotelName = x.Hotel.Name,
                HotelId = x.Hotel.Id,
                Name = x.Name,
                Price = x.Price,
                Size = x.Size,
                Amenities = x.AmenityRooms.Where(x => x.Amenity.AmenityType == AmenityType.Room).Select(x => x.Amenity.Title).ToList(),
                ImagesSrc = ComposeImageUri(x.Images.Select(x => x.Src).ToList()),
                ServiceAmenities = x.AmenityRooms.Where(x => x.Amenity.AmenityType == AmenityType.RoomService).Select(x => x.Amenity.Title).ToList()
            }).FirstOrDefault(x => x.Id == id);

        if (room == null)
            return new BaseDto<DetailRoomDto>
            {
                IsSuccess = false
            };
        return new BaseDto<DetailRoomDto>
        {
            Data = room,
            IsSuccess = true
        };
    }
}
