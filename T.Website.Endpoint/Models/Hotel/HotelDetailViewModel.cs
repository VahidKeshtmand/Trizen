using T.Domain.Hotels;

namespace T.Website.Endpoint.Models.Hotel;

public class HotelDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<string> HotelImagesSrc { get; set; }
    public string ImageSrc { get; set; }
    public int StarCount { get; set; }
    public string City { get; set; }
    public string Description { get; set; }
    public List<HotelDetailRoomListViewModel> Rooms { get; set; }
    public List<string> Amenities { get; set; }
    public string LowestPrice { get; set; }
    public ExtraPeople ExtraPeople { get; set; }
    public string Country { get; set; }
    public Cancellation Cancellation { get; set; }
    public string Slug { get; set; }
}

