using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Common;
using T.Application.Dtos.Discounts;
using T.Common;
using T.Domain.Discounts;

namespace T.Application.Services.Discounts;

public interface IDiscountService
{
    BaseDto Add(AddDiscountDto model);
    string GetExistenceName(int roomId, int hotelId);
    int GetHotelId(int? roomId);
    int GetAirlineCompanyId(int? flightId);
    BaseDto Delete(int id);
    BaseDto<EditDiscountDto> Find(int id);
    BaseDto Edit(EditDiscountDto model);
}

public class DiscountService : IDiscountService
{
    private readonly IDatabaseContext _databaseContext;

    public DiscountService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    private bool CheckRoomDiscountExist(int? roomId)
    {
        return _databaseContext.Discounts.Any(x => x.RoomId == roomId && x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);
    }

    private bool CheckFlightDiscountExist(int? flightId)
    {
        return _databaseContext.Discounts.Any(x => x.FlightId == flightId && x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);
    }

    public BaseDto Add(AddDiscountDto model)
    {
        var startDate = model.DiscountDate.Substring(0, 10).ToGeorgianDateTime();
        var endDate = model.DiscountDate.Substring(13).ToGeorgianDateTime();
        if (endDate < DateTime.Now)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "تاریخ قبل از امروز را نمی توانید انتخاب کنید !"
            };
        if (model.RoomId != null)
        {
            var isDiscountExist = CheckRoomDiscountExist(model.RoomId);
            if (isDiscountExist)
                return new BaseDto
                {
                    IsSuccess = false,
                    Message = "تخفیف موجود است. در صورتی که می خواهید تخفیف جدید اضافه کنید ابتدا تخفیف قبلی را حذف کنید !"
                };
            var discount = new Discount
            {
                Percent = model.Percent,
                RoomId = model.RoomId,
                StartDate = startDate,
                EndDate = endDate,
                Description = model.Description
            };
            _databaseContext.Discounts.Add(discount);
        }
        if (model.HotelId != null)
        {
            var rooms = _databaseContext.Hotels.Include(x => x.Rooms)
                .Select(x => new { x.Id, x.Rooms }).FirstOrDefault(x => x.Id == model.HotelId);
            if (rooms == null)
                return new BaseDto
                {
                    IsSuccess = false
                };
            foreach (var item in rooms.Rooms)
            {
                var isDiscountExist = CheckRoomDiscountExist(item.Id);
                if (isDiscountExist)
                    return new BaseDto
                    {
                        IsSuccess = false,
                        Message = "تخفیف موجود است. در صورتی که می خواهید تخفیف جدید اضافه کنید ابتدا تخفیف قبلی را حذف کنید !"
                    };
                _databaseContext.Discounts.Add(new Discount
                {
                    Percent = model.Percent,
                    RoomId = item.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    Description = model.Description
                });
            }

        }
        if (model.FlightId != null)
        {
            var isDiscountExist = CheckFlightDiscountExist(model.FlightId);
            if (isDiscountExist)
                return new BaseDto
                {
                    IsSuccess = false,
                    Message = "تاریخ قبل از امروز را نمی توانید انتخاب کنید !"
                };
            var discount = new Discount
            {
                Percent = model.Percent,
                FlightId = model.FlightId,
                StartDate = startDate,
                EndDate = endDate,
                Description = model.Description
            };
            _databaseContext.Discounts.Add(discount);
        }

        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true
        };
    }

    public BaseDto Delete(int id)
    {
        var discount = _databaseContext.Discounts.FirstOrDefault(x => x.Id == id);
        if (discount == null)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "تخفیف پیدا نشد !"
            };

        _databaseContext.Discounts.Remove(discount);
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "تخفیف با موفقیت حذف شد !"
        };
    }

    public BaseDto Edit(EditDiscountDto model)
    {
        var startDate = model.DiscountDate.Substring(0, 10).ToGeorgianDateTime();
        var endDate = model.DiscountDate.Substring(13).ToGeorgianDateTime();
        if (endDate < DateTime.Now)
            return new BaseDto
            {
                IsSuccess = false,
                Message = "تاریخ قبل از امروز را نمی توانید انتخاب کنید !"
            };
        var discount = _databaseContext.Discounts.FirstOrDefault(x => x.Id == model.Id);
        if (discount == null)
            return new BaseDto
            {
                IsSuccess = false
            };
        discount.Description = model.Description;
        discount.Percent = model.Percent;
        discount.StartDate = startDate;
        discount.EndDate = endDate;
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true,
            Message = "ویرایش با موفقیت انجام شد !"
        };
    }

    public BaseDto<EditDiscountDto> Find(int id)
    {
        var discount = _databaseContext.Discounts.Where(x => x.Id == id);
        if (discount == null)
            return new BaseDto<EditDiscountDto>
            {
                IsSuccess = false,
                Message = "پیدا نشد !"
            };
        if (discount.Select(x => x.RoomId) != null)
        {
            var model = discount.Include(x => x.Room).Include(x => x.Flight).Select(x => new EditDiscountDto
            {
                Description = x.Description,
                DiscountDate = x.StartDate.ToShamsi() + " - " + x.EndDate.ToShamsi(),
                Percent = x.Percent,
                ExistenceName = x.Room.Name,
                RoomId = x.RoomId,
                Id = x.Id,
                HotelId = x.Room.HotelId,
                FlightId = x.Flight.Id
            }).FirstOrDefault();

            return new BaseDto<EditDiscountDto>
            {
                Data = model,
                IsSuccess = true
            };
        }
        return new BaseDto<EditDiscountDto>
        {
            IsSuccess = false
        };

    }

    public string GetExistenceName(int roomId, int hotelId)
    {
        if (roomId != 0)
            return _databaseContext.Rooms.Select(x => new { x.Name, x.Id }).FirstOrDefault(x => x.Id == roomId).Name;

        if (hotelId != 0)
            return _databaseContext.Hotels.Select(x => new { x.Name, x.Id }).FirstOrDefault(x => x.Id == hotelId).Name;

        return string.Empty;
    }

    public int GetHotelId(int? roomId)
    {
        if (roomId == null || roomId == 0)
            return 0;
        return _databaseContext.Rooms.Select(x => new { x.HotelId, x.Id }).FirstOrDefault(x => x.Id == roomId).HotelId;
    }

    public int GetAirlineCompanyId(int? flightId)
    {
        return _databaseContext.Flights.Select(x => new { x.AirlineCompanyId, x.Id }).FirstOrDefault(x => x.Id == flightId).AirlineCompanyId;
    }
}
