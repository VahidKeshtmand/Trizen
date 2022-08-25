namespace T.Website.Endpoint.Models.Comments;

public class AddCommentViewModel
{
    public int ServiceRate { get; set; }
    public int LocationRate { get; set; }
    public int FacilityRate { get; set; }
    public int ValueForMoneyServiceRate { get; set; }
    public int AmenityRate { get; set; }
    public int CleanlinessRate { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public int? HotelId { get; set; }
    public int? FlightId { get; set; }
    public string UserId { get; set; } = string.Empty;

}

public class CommentViewModel
{
    public int Rate { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public string Date { get; set; }

}
