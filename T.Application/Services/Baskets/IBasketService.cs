using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Application.Dtos.Baskets;
using T.Application.Dtos.Common;
using T.Common;
using T.Domain.Baskets;

namespace T.Application.Services.Baskets;

public interface IBasketService
{
    BasketDto GetOrCreateBasketForUser(string buyerId);
    void AddRoomToBasket(int basketId, int roomId, string checkInDate, string checkOutDate, int guestsNumber, int discountPercent, int quantity = 1);
    BaseDto DeleteItem(int id);
    void TransferBasket(string anonymousId, string userId);
}

public class BasketService : IBasketService
{
    private readonly IDatabaseContext _databaseContext;

    public BasketService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void AddRoomToBasket(int basketId, int roomId, string checkInDate, string checkOutDate, int guestsNumber, int discountPercent, int quantity = 1)
    {
        var basket = _databaseContext.Baskets.FirstOrDefault(x => x.Id == basketId);
        if (basket == null)
            throw new Exception("");
        var roomPrice = _databaseContext.Rooms.Select(x => new { x.Price, x.Id }).FirstOrDefault(x => x.Id == roomId).Price;
        basket.Add(roomId, quantity, roomPrice, checkInDate.ToGeorgianDateTime(), checkOutDate.ToGeorgianDateTime(), guestsNumber, discountPercent);
        _databaseContext.SaveChanges();

    }

    public BasketDto GetOrCreateBasketForUser(string buyerId)
    {
        var basket = _databaseContext.Baskets
            .Include(x => x.BasketItems)
            .ThenInclude(x => x.Room)
            .ThenInclude(x => x.Images)
            .Include(x => x.BasketItems)
            .ThenInclude(x => x.Room)
            .ThenInclude(x => x.Discounts)
            .Include(x => x.BasketItems)
            .ThenInclude(x => x.Room)
            .ThenInclude(x => x.Hotel)
            .FirstOrDefault(x => x.BuyerId == buyerId);
        if (basket == null)
        {
            var newBasket = new Basket(buyerId);
            _databaseContext.Baskets.Add(newBasket);
            _databaseContext.SaveChanges();
            return new BasketDto
            {
                BuyerId = newBasket.BuyerId,
                Id = newBasket.Id
            };
        }
        var basketDto = new BasketDto
        {
            BuyerId = basket.BuyerId,
            Id = basket.Id,

            BasketItems = basket.BasketItems.Select(x => new BasketItemDto
            {
                Id = x.Id,
                Quantity = x.Quantity,
                RoomId = x.RoomId,
                RoomName = x.Room.Name,
                UnitPrice = x.UnitPrice,
                CheckInDate = x.CheckInDate.ToFarsi(),
                CheckOutDate = x.CheckOutDate.ToFarsi(),
                Days = (x.CheckOutDate - x.CheckInDate).TotalDays,
                DiscountPercent = x.DiscountPercent,
                TotalPrice = x.UnitPrice * x.Quantity * (x.CheckOutDate - x.CheckInDate).TotalDays,
                BedNumber = x.GuestsNumber,
                TotalPriceWithDiscount = GetTotalPriceWithDiscount(x.UnitPrice, x.Quantity, x.DiscountPercent, (x.CheckOutDate - x.CheckInDate).TotalDays),
                ImageSrc = x.Room.Images.Select(x => x.Src).FirstOrDefault() ?? "",
                Slug = x.Room.Slug,
                HotelSlug = x.Room.Hotel.Slug,
                Address = x.Room.Hotel.Address,
                HotelName = x.Room.Hotel.Name

            }).ToList(),

        };
        double totalPriceBasket = 0;
        double totalPricePayable = 0;
        foreach (var item in basketDto.BasketItems)
        {
            totalPriceBasket += item.TotalPrice;
            totalPricePayable += item.TotalPriceWithDiscount;
        }
        basketDto.TotalPriceBasket = totalPriceBasket;
        basketDto.TotalPriceDiscount = totalPriceBasket - totalPricePayable;
        basketDto.TotalPricePayable = totalPricePayable;
        return basketDto;
    }
    public static double GetTotalPriceWithDiscount(int unitPrice, int quantity, int percent, double days)
    {
        return (unitPrice * quantity) * (100 - percent) * 0.01 * days;
    }
    private static string ComposeImageUri(string imageSrc)
    {
        return "https://localhost:7235/" + imageSrc.Replace("\\", "//");
    }

    public BaseDto DeleteItem(int id)
    {
        var item = _databaseContext.BasketItems.Find(id);
        if (item == null)
            return new BaseDto
            {
                IsSuccess = false
            };
        _databaseContext.BasketItems.Remove(item);
        _databaseContext.SaveChanges();
        return new BaseDto
        {
            IsSuccess = true
        };
    }

    public void TransferBasket(string anonymousId, string userId)
    {
        var anonymousBasket = _databaseContext.Baskets.Include(x => x.BasketItems)
            .SingleOrDefault(x => x.BuyerId == anonymousId);

        if (anonymousBasket == null) return;
        var userBasket = _databaseContext.Baskets.Include(x => x.BasketItems)
            .FirstOrDefault(x => x.BuyerId == userId);

        if (userBasket == null)
        {
            userBasket = new Basket(userId);
            _databaseContext.Baskets.Add(userBasket);
        }

        foreach (var item in anonymousBasket.BasketItems)
        {
            userBasket.Add(item.RoomId, item.Quantity, item.UnitPrice, item.CheckInDate, item.CheckOutDate, item.GuestsNumber, item.DiscountPercent);
        }

        _databaseContext.Baskets.Remove(anonymousBasket);
        _databaseContext.SaveChanges();

    }
}
