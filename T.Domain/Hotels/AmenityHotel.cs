using T.Domain.Attributes;
using T.Domain.Common;

namespace T.Domain.Hotels
{
    public class AmenityHotel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
    }

}


