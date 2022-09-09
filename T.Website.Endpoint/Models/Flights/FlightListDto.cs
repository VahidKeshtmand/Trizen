using T.Domain.Flights;
using T.Website.Endpoint.Models.Comments;

namespace T.Website.Endpoint.Models.Flights;

public class FlightListViewModel
{
    public string Destination { get; set; }
    public FlightType FlightType { get; set; }
    public int Price { get; set; }
    public DateTime TakeOff { get; set; }
    public string TakeOffTime { get; set; }
    public DateTime Landing { get; set; }
    public string LogoSrc { get; set; }
    public string TotalTimeOfFlight { get; set; }
    public string Slug { get; set; }
    public string AirlineCompanyName { get; set; }

}

public class FlightDetailViewModel
{
    public int Id { get; set; }
    public List<string> Images { get; set; }
    public string FirstImage { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string FlightType { get; set; }
    public DateTime TakeOff { get; set; }
    public string TakeOffTime { get; set; }
    public DateTime Landing { get; set; }
    public string AirlineCompanyName { get; set; }
    public Coach Coach { get; set; }
    public string Refundable { get; set; } = string.Empty;
    public int CancellationCharge { get; set; }
    public int BasePrice { get; set; }
    public string PriceWithDiscount { get; set; }
    public int ExtraFee { get; set; }
    public string AirlineCompanyDescription { get; set; }
    public string Slug { get; set; }
    public string TotalTimeOfFlight { get; set; }
    public List<int> Discounts { get; set; }

    public List<string> Amenities { get; set; }
    public List<CommentViewModel> Comments { get; set; }


}
