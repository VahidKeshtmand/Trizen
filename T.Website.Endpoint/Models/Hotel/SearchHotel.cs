using System.ComponentModel.DataAnnotations;

namespace T.Website.Endpoint.Models.Hotel;

public class SearchHotel
{
    public string City { get; set; }
    public string dateRange { get; set; }
    public string LowestPrice { get; set; }
    public string HighestPrice { get; set; }
    public int StarNumber { get; set; }
    public BedNumber BedNumber { get; set; }
    public Dictionary<int, string> AmenitiesValue { get; set; }
    public List<AmenityDto>? Amenities { get; set; } = new();

}

public enum BedNumber
{
    [Display(Name = "یک تخته")]
    OneBed = 1,
    [Display(Name = "دو تخته")]
    TwoBed = 2,
    [Display(Name = "سه تخته")]
    ThreeBed = 3,
    [Display(Name = "چهار تخته")]
    FourBed = 4,
    [Display(Name = "پنج تخته")]
    FiveBed = 5,
    [Display(Name = "شیش تخته")]
    SixBed = 6,
}