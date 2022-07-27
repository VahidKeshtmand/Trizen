using T.Domain.Attributes;

namespace T.Domain.Hotels
{
    [Auditable]
    public class Amenity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Display { get; set; } = string.Empty;

        public List<AmenityHotel> AmenityHotels { get; set; }
    }

    public class AmenityHotel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }

}


