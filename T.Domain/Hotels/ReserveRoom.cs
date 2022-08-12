using T.Domain.Attributes;

namespace T.Domain.Hotels;

[Auditable]
public class ReserveRoom
{
    public int Id { get; set; }
    public int AdultGuest { get; set; }
    public int ChildrenGuest { get; set; }
    public int Infant { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public bool IsReserve { get; set; }
    public bool CleaningFee { get; set; }
    public bool AirportPickup { get; set; }
    public bool Breakfast { get; set; }
    public bool Parking { get; set; }
    public int TotalPrice { get; set; }
    public int PaymentAmount { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }
}