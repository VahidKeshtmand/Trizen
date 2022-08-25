using T.Domain.Attributes;
using T.Domain.Common;

namespace T.Domain.Flights;

[Auditable]
public class Seat
{
    public int Id { get; set; }
    public int Price { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public string Description { get; set; }
    public Image Image { get; set; }
    public int ImageId { get; set; }
    public int Quantity { get; set; }


}
