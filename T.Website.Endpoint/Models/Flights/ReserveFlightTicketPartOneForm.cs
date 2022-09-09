namespace T.Website.Endpoint.Models.Flights;

public class ReserveFlightTicketPartOneForm
{
    public int FlightId { get; set; }
    public string FlightSlug { get; set; }
    public int SeatCount { get; set; }

}
