using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common
{
    [Auditable]
    public class Amenity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Display { get; set; } = string.Empty;
        public AmenityType AmenityType { get; set; } = AmenityType.Hotel;
        public List<AmenityHotel> AmenityHotels { get; set; }

    }

    public enum AmenityType
    {
        Hotel,
        Room,
        RoomService
    }

}


