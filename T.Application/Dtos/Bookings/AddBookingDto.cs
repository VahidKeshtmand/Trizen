namespace T.Application.Dtos.Bookings;

public class AddBookingDto
{
    public string BuyerId { get; private set; }
    public int SeatCount { get; set; }
    public int FlightId { get; set; }
}
