using Microsoft.EntityFrameworkCore;
using OS.Application.Interfaces.Contexts;
using T.Domain.Reserves;

namespace T.Application.Services.Orders;

public interface IOrderService
{
    int Create(int basketId);
}

public class OrderService : IOrderService
{
    private readonly IDatabaseContext _databaseContext;

    public OrderService(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public int Create(int basketId)
    {
        var basket = _databaseContext.Baskets.Include(x => x.BasketItems).FirstOrDefault(x => x.Id == basketId);
        var ids = basket.BasketItems.Select(x => x.Id).ToArray();
        var items = _databaseContext.BasketItems.Where(x => ids.Contains(x.Id)).ToList();
        var list = new List<ReserveRoom>();
        foreach (var item in items)
        {

            list.Add(new ReserveRoom(item.CheckInDate, item.CheckOutDate,
                 item.UnitPrice, item.RoomId, item.Quantity, item.DiscountPercent));
        }
        var reserve = new Reserve(basket.BuyerId, list);
        _databaseContext.Reserves.Add(reserve);
        _databaseContext.Baskets.Remove(basket);
        _databaseContext.BasketItems.RemoveRange(items);
        _databaseContext.SaveChanges();
        return reserve.Id;


    }


}