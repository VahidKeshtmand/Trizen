namespace T.Website.Endpoint.Models.Hotel;

public class RoomListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Amenities { get; set; }
    public string Price { get; set; }
    public List<string> ImagesSrc { get; set; }
    public int BedCount { get; set; }
    public int Size { get; set; }
    public string HotelSlug { get; set; }
    public string RoomSlug { get; set; }
    public string Description { get; set; }

}

public class HotelDetailRoomListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Amenities { get; set; }
    public string Price { get; set; }
    public string ImageSrc { get; set; }
    public string Slug { get; set; }

}

public class RoomDetails
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public List<string> ImagesSrc { get; set; }
    public string Name { get; set; }
    public double UserRate { get; set; }
    public int CommentCount { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string PriceWithDiscount { get; set; }
    public List<int> Discounts { get; set; }
    public List<string> Services { get; set; }
    public List<string> Amenities { get; set; }
    public int Count { get; set; }

}