using T.Domain.Account;
using T.Domain.Attributes;
using T.Domain.Flights;
using T.Domain.Hotels;

namespace T.Domain.Comments;

[Auditable]
public class Comment
{
    public int Id { get; set; }
    public int ServiceRate { get; set; }
    public int LocationRate { get; set; }
    public int FacilityRate { get; set; }
    public int ValueForMoneyService { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public CommentStatus CommentStatus { get; set; }
    public string UserId { get; set; }
    public Hotel Hotel { get; set; }
    public int? HotelId { get; set; }
    public Flight Flight { get; set; }
    public int? FlightId { get; set; }
}

public enum CommentStatus
{
    Waiting,
    Confirmed,
}
