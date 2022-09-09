using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Baskets;

[Auditable]
public class Basket
{
    public int Id { get; set; }
    public string BuyerId { get; private set; }

    //در اینجا می خواهیم فقط Get رو در اختیار لایه های بالاتر قرار بدیم و لایه های بالاتر نتوانند ست کنند.
    private readonly List<BasketItem> _BasketItems = new();
    public ICollection<BasketItem> BasketItems => _BasketItems.AsReadOnly();

    public Basket(string buyerId)
    {
        BuyerId = buyerId;
    }

    public void Add(int roomId, int quantity, int unitPrice, DateTime checkIn, DateTime checkOut, int guestsNumber, int discountPercent)
    {
        if (!BasketItems.Any(x => x.RoomId == roomId))
        {
            _BasketItems.Add(new BasketItem(roomId, unitPrice, checkIn, checkOut, guestsNumber, discountPercent));
        }
        var basketItem = BasketItems.FirstOrDefault(x => x.RoomId == roomId);
        basketItem.AddQuantity(quantity);

    }
}

[Auditable]
public class BasketItem
{
    public int Id { get; private set; }
    public int UnitPrice { get; private set; }
    public int DiscountPercent { get; private set; }
    public int Quantity { get; private set; }
    public int GuestsNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public Room Room { get; private set; }
    public int RoomId { get; private set; }

    public Basket Basket { get; private set; }
    public int BasketId { get; private set; }

    public BasketItem(int roomId, int unitPrice, DateTime checkInDate, DateTime checkOutDate, int guestsNumber, int discountPercent)
    {
        RoomId = roomId;
        UnitPrice = unitPrice;
        GuestsNumber = guestsNumber;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        GuestsNumber = guestsNumber;
        DiscountPercent = discountPercent;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
}

