using T.Domain.Flights;

namespace T.Application.Dtos.Flights;

public class FlightListDto
{
    public int Id { get; set; }
    public string FlyingFrom { get; set; }
    public string FlyingTo { get; set; }
    public string TakeOffDate { get; set; }
    public string ReturnTakeOffDate { get; set; }
    public string AirportOrigin { get; set; }
    public string AirportDestination { get; set; }
    public int DiscountPercent { get; set; }
    public int DiscountId { get; set; }
    public int AvailableSeats { get; set; }
    public FlightType FlightType { get; set; }

}


