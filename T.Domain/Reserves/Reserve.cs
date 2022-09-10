using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Reserves;

[Auditable]
public class Reserve
{
    public int Id { get; set; }
    public string UserId { get; private set; }
    public DateTime DateTime { get; private set; } = DateTime.Now;
    public PaymentStatus PaymentStatus { get; private set; }
    private readonly List<ReserveRoom> _reserveRooms = new List<ReserveRoom>();
    public IReadOnlyCollection<ReserveRoom> ReserveRooms => _reserveRooms.AsReadOnly();

    public Reserve() { }
    public Reserve(string userId, List<ReserveRoom> reserveRooms)
    {
        UserId = userId;
        _reserveRooms = reserveRooms;
    }
    public void PaymentDone()
    {
        PaymentStatus = PaymentStatus.Paid;
    }
    public double TotalPrice()
    {
        return _reserveRooms.Sum(x => (x.UnitPrice * x.Count * (x.CheckOut - x.CheckIn).TotalDays) * (100 - x.DiscountPercent) * 0.01);
    }

}

public enum PaymentStatus
{
    WaitingForPayment = 0,
    Paid = 1
}

[Auditable]
public class ReserveRoom
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int UnitPrice { get; set; }
    public int DiscountPercent { get; set; }
    public int Count { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }

    public ReserveRoom(DateTime checkIn, DateTime checkOut, int unitPrice, int roomId, int count, int discountPercent)
    {
        CheckIn = checkIn;
        CheckOut = checkOut;
        UnitPrice = unitPrice;
        RoomId = roomId;
        Count = count;
        DiscountPercent = discountPercent;
    }
}

