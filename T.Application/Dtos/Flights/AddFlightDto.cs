using Microsoft.AspNetCore.Http;
using T.Application.Dtos.Hotels;
using T.Domain.Flights;

namespace T.Application.Dtos.Flights;

public class AddFlightDto
{
    public string FlyingFrom { get; set; }
    public string FlyingTo { get; set; }
    public FlightType FlightType { get; set; }
    public string TakeOffDate { get; set; }
    public string TakeOffTime { get; set; }
    public string LandingDate { get; set; }
    public string ReturnTakeOffDate { get; set; }
    public string ReturnTakeOffTime { get; set; }
    public string ReturnLandingDate { get; set; }
    public int SeatNumber { get; set; }
    public Coach Coach { get; set; }
    public int AirlineCompanyId { get; set; }
    public int TotalTimeOfFlight { get; set; }
    public int PriceRange { get; set; }
    public int CancellationPrice { get; set; }
    public string Refundable { get; set; }
    public int TaxesAndFees { get; set; }
    public int BasePrice { get; set; }
    public string Description { get; set; }
    public string AirportOrigin { get; set; }
    public string AirportDestination { get; set; }
    public List<IFormFile> Images { get; set; }
    public List<string>? ImagesSrc { get; set; }
    public List<ImageDto>? ImagesModel { get; set; }
    public Dictionary<int, string> AmenitiesValue { get; set; }
    public int CurrencyValue { get; set; }
    public InformationForAddFlightDto Information { get; set; }
}


