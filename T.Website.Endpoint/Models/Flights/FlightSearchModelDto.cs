namespace T.Website.Endpoint.Models.Flights;

public class FlightSearchModelDto
{
    public string TakeOffDate { get; set; }
    public string LandingDate { get; set; }
    public string Destination { get; set; }
    public string AirlineCompany { get; set; }
}
