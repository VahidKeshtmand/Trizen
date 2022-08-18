namespace T.Application.Dtos.Baskets;

public class BasketDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
}

public class BasketItemDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public int UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int DiscountPercent { get; set; }
    public int BedNumber { get; set; }
    public string CheckInDate { get; set; }
    public string CheckOutDate { get; set; }
    public int TotalPrice { get; set; }
    public string TotalPriceWithDiscount { get; set; }
    public string ImageSrc { get; set; }
    public string Slug { get; set; }
    public string HotelSlug { get; set; }
    public int Days { get; set; }

}
