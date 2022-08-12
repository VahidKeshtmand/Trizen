using T.Domain.Attributes;
using T.Domain.Common;

namespace T.Domain.Hotels;


public class AmenityRoom
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }

    public int AmenityId { get; set; }
    public Amenity Amenity { get; set; }
}
