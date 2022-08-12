using T.Application.Dtos.Common;

namespace T.Application.Dtos.Rooms;

public class RoomListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsReserve { get; set; }
    public int BedCount { get; set; }
    public int Price { get; set; }
}

public class RoomIndexDto
{
    public PaginatedItemsDto<RoomListDto> RoomList { get; set; }
    public string HotelName { get; set; }
    public int HotelId { get; set; }
}