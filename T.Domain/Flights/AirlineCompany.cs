using T.Domain.Attributes;
using T.Domain.Common;

namespace T.Domain.Flight;

[Auditable]
public class AirlineCompany
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
    public Image Image { get; set; }
    public List<Flight> Flights { get; set; }
}

[Auditable]
public class Flight
{
    public int Id { get; set; }
    public string FlyingFrom { get; set; }
    public int FlyingTo { get; set; }
    public FlightType FlightType { get; set; }
    public DateTime TakeOff { get; set; }
    public DateTime Landing { get; set; }
    public int SeatNumber { get; set; }
    public Coach Coach { get; set; }
    public int AirlineCompanyId { get; set; }
    public AirlineCompany AirlineCompany { get; set; }
    public int TotalTimeOfFlight { get; set; }
    public int PriceRange { get; set; }
    public string Refundable { get; set; }
    public int CancellationCharge { get; set; }
    public int FlightChange { get; set; }
    public int TaxesAndFees { get; set; }
    public int BasePrice { get; set; }
    public string Description { get; set; }

    public List<Image> Images { get; set; }
    public List<Amenity> Amenities { get; set; }
    public List<Country> Countries { get; set; }
    public Currency Currency { get; set; }
    public int CurrencyId { get; set; }
    public Contact Contact { get; set; }
    public int ContactId { get; set; }
    public List<Seat> Seats { get; set; }

}

[Auditable]
public class Seat
{
    public int Id { get; set; }
    public int Price { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public string Description { get; set; }
    public Image Image { get; set; }
    public int ImageId { get; set; }

}

public enum FlightType
{
    OneWay,
    RoundTrip
}

public enum Coach
{
    Economy,
    Business,
    FirstClass
}