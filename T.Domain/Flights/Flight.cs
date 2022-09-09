using T.Domain.Attributes;
using T.Domain.Comments;
using T.Domain.Common;
using T.Domain.Discounts;
using T.Domain.Bookings;

namespace T.Domain.Flights;

[Auditable]
public class Flight
{
    public int Id { get; set; }
    public string FlyingTo { get; set; } = string.Empty;
    public string FlyingFrom { get; set; } = string.Empty;
    public FlightType FlightType { get; set; }
    public DateTime TakeOffDate { get; set; }
    public DateTime LandingDate { get; set; }
    public DateTime ReturnTakeOffDate { get; set; }
    public DateTime ReturnLandingDate { get; set; }
    public int SeatNumber { get; set; }
    public Coach Coach { get; set; }
    public int AirlineCompanyId { get; set; }
    public AirlineCompany AirlineCompany { get; set; }
    public int TotalTimeOfFlight { get; set; }
    public int PriceRange { get; set; }
    public string Refundable { get; set; } = string.Empty;
    public int CancellationCharge { get; set; }
    public int TaxesAndFees { get; set; }
    public int BasePrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AirportOrigin { get; set; } = string.Empty;
    public string AirportDestination { get; set; } = string.Empty;
    public string Slug { get; set; }

    public List<Image> Images { get; set; }
    public Currency Currency { get; set; }
    public List<Booking> Booking { get; set; }
    public int CurrencyId { get; set; }
    public List<Seat> Seats { get; set; }
    public List<AmenityFlight> AmenityFlights { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Discount> Discounts { get; set; }

}
