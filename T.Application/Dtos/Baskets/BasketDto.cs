namespace T.Application.Dtos.Baskets;

public class BasketDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public int TotalPriceBasket { get; set; }
    public double TotalPriceDiscount { get; set; }
    public double TotalPricePayable { get; set; }
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
    public List<int> DiscountPercents { get; set; }
    public int BedNumber { get; set; }
    public string CheckInDate { get; set; }
    public string CheckOutDate { get; set; }
    public int TotalPrice { get; set; }
    public double TotalPriceWithDiscount { get; set; }
    public string ImageSrc { get; set; }
    public string Slug { get; set; }
    public string HotelSlug { get; set; }
    public double Days { get; set; }
    public string Address { get; set; }
    public string HotelName { get; set; }

}
