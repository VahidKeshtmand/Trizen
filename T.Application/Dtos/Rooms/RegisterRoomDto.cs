using Microsoft.AspNetCore.Http;
using T.Application.Dtos.Common;

namespace T.Application.Dtos.Rooms;

public class RegisterRoomDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BedCount { get; set; }
    public int Size { get; set; }
    public int Price { get; set; }
    public int HotelId { get; set; }
    public List<IFormFile> Images { get; set; } = new();
    public List<string> ImagesSrc { get; set; } = new();

    public Dictionary<int, string> AmenitiesValue { get; set; } = new();
    public Dictionary<int, string> ServiceAmenitiesValue { get; set; } = new();
    public InformationRoomDto Information { get; set; } = new();
}
