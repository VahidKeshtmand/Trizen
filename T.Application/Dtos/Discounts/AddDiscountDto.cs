namespace T.Application.Dtos.Discounts;

public class AddDiscountDto
{
    public string DiscountDate { get; set; }
    public int Percent { get; set; }
    public int? RoomId { get; set; }
    public int? HotelId { get; set; }
    public string ExistenceName { get; set; }
    public string? Description { get; set; }

}

public class EditDiscountDto : AddDiscountDto
{
    public int Id { get; set; }
}
