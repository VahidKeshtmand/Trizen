using T.Domain.Attributes;
using T.Domain.Hotels;

namespace T.Domain.Common;

[Auditable]
public class Image
{
    public int Id { get; set; }
    public string Src { get; set; }

    public Hotel? Hotel { get; set; }
    public int? HotelId { get; set; }

    public Room? Room { get; set; }
    public int? RoomId { get; set; }
}
