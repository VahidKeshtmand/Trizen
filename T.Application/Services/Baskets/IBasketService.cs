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
            .SingleOrDefault(x => x.BuyerId == buyerId);
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
                DiscountPercent = x.Room.Discounts.Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now).Select(x => x.Percent).LastOrDefault(),
                TotalPrice = x.UnitPrice * x.Quantity,
                BedNumber = x.GuestsNumber,
                TotalPriceWithDiscount = (x.UnitPrice * x.Quantity) - ((x.UnitPrice * x.Quantity) * (100 - x.Room.Discounts.Where(x => x.EndDate > DateTime.Now && x.StartDate < DateTime.Now).Select(x => x.Percent).LastOrDefault()) * 0.01),
                ImageSrc = ComposeImageUri(x.Room.Images.Select(x => x.Src).FirstOrDefault() ?? ""),
                Slug = x.Room.Slug,
                HotelSlug = x.Room.Hotel.Slug,
                Address = x.Room.Hotel.Address,
                HotelName = x.Room.Hotel.Name
            }).ToList(),

        };
        basketDto.TotalPriceBasket = basketDto.BasketItems.Select(x => x.TotalPrice).Sum();
        basketDto.TotalPriceDiscount = basketDto.BasketItems.Select(x => x.TotalPriceWithDiscount).Sum();
        basketDto.TotalPricePayable = basketDto.BasketItems.Select(x => x.TotalPrice - (int)x.TotalPriceWithDiscount).Sum();
        return basketDto;
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
        var anonymousBasket = _databaseContext.Baskets
            .SingleOrDefault(x => x.BuyerId == anonymousId);

        if (anonymousBasket == null) return;
        var userBasket = _databaseContext.Baskets
            .SingleOrDefault(x => x.BuyerId == userId);

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
