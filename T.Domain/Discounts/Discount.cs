using T.Domain.Attributes;
using T.Domain.Flights;
using T.Domain.Hotels;

namespace T.Domain.Discounts;

[Auditable]
public class Discount
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Percent { get; set; }
    public int? RoomId { get; set; }
    public Room Room { get; set; }
    public int? FlightId { get; set; }
    public Flight Flight { get; set; }
    public string? Description { get; set; }
}
