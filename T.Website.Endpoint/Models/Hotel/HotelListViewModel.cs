namespace T.Website.Endpoint.Models.Hotel;

public class HotelListViewModel
{
    public int Id { get; set; }
    public string ImageSrc { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int LowestPrice { get; set; }
    public int HighestPrice { get; set; }
    public double UserRate { get; set; }
    public int CommentCount { get; set; }
    public List<int> BedNumbers { get; set; }
    public int StarCount { get; set; }
    public string City { get; set; }
    public List<int> Amenities { get; set; }
    public bool IsAmenitiesExist { get; set; }
    public bool IsBedNumberExist { get; set; }

}

public enum Sort
{
    MostVisited,
    Cheapest,
    MostExpensive,
    MostPopular
}

public enum RateResult
{
    Perfect,
    VeryGood,
    Medium,
    Weak,
    VeryWeak
}

