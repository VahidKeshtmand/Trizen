using T.Domain.Attributes;
using T.Domain.Common;
using T.Domain.Discounts;

namespace T.Domain.Hotels;

[Auditable]
public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BedCount { get; set; }
    public int Size { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
    public bool IsReserve { get; set; } = false;
    public string Slug { get; set; }

    public Hotel Hotel { get; set; }
    public int HotelId { get; set; }
    public List<AmenityRoom> AmenityRooms { get; set; }
    public List<Image> Images { get; set; }
    public List<Discount> Discounts { get; set; }

    // public List<ReserveRoom> ReserveRooms { get; set; }
}
