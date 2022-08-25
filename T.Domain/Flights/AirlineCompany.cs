using System.ComponentModel.DataAnnotations;
using T.Domain.Attributes;
using T.Domain.Common;

namespace T.Domain.Flights;

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

public enum FlightType
{
    [Display(Name = "یک طرفه")]
    OneWay,
    [Display(Name = "رفت و برگشت")]
    RoundTrip
}

public enum Coach
{
    [Display(Name = "اقتصادی")]
    Economy,
    [Display(Name = "تجاری")]
    Business,
    [Display(Name = "فرست کلس")]
    FirstClass
}