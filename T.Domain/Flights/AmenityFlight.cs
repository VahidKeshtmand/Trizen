using T.Domain.Common;

namespace T.Domain.Flights;

public class AmenityFlight
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }

    public int AmenityId { get; set; }
    public Amenity Amenity { get; set; }
}
