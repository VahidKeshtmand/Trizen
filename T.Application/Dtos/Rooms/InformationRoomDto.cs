using T.Application.Dtos.Common;

namespace T.Application.Dtos.Rooms;

public class InformationRoomDto
{
    public List<AmenityDto> Amenities { get; set; } = new();
    public List<AmenityDto> ServiceAmenities { get; set; } = new();
    public string HotelName { get; set; } = string.Empty;
    public int HotelId { get; set; }

}
