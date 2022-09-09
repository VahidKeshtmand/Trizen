namespace T.Application.Dtos.Rooms;

public class SearchRoomDto
{
    public string Slug { get; set; }
    public string CheckInCheckOutDate { get; set; }
    public int BedCount { get; set; }

}

public class DetailRoomDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BedCount { get; set; }
    public int Size { get; set; }
    public int Price { get; set; }
    public int HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public List<string> ImagesSrc { get; set; } = new();
    public List<string> Amenities { get; set; } = new();
    public List<string> ServiceAmenities { get; set; } = new();

}
