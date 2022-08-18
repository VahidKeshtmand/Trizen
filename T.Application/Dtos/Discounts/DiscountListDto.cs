namespace T.Application.Dtos.Discounts;

public class DiscountListDto
{
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int Percent { get; set; }
    public int? RoomId { get; set; }
    public string RoomName { get; set; }
    public int? HotelId { get; set; }
    public string HotelName { get; set; }


}
