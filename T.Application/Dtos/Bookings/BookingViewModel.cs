namespace T.Application.Dtos.Bookings;

public class BookingViewModel
{
    public int Id { get; set; }
    public int CommentCount { get; set; }
    public int FlightId { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string ImageSrc { get; set; }
    public string FlightType { get; set; }
    public double Rate { get; set; }
    public string TakeOff { get; set; }
    public string TakeOffTime { get; set; }
    public string Landing { get; set; }
    public string TotalTimeOfFlight { get; set; }
    public string AirlineCompanyName { get; set; }
    public string Coach { get; set; }
    public int ExtraFee { get; set; }
    public int BasePrice { get; set; }
    public int SeatCount { get; set; }
    public int TotalPrice { get; set; }
    public List<int> Discounts { get; set; }
    public double TotalPriceWithDiscount { get; set; }

}