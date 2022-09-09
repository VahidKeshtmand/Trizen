using T.Domain.Attributes;
using T.Domain.Flights;

namespace T.Domain.Bookings;

[Auditable]
public class Booking
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public int SeatCount { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
}
