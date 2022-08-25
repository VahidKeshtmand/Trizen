using T.Domain.Comments;

namespace T.Application.Dtos.Comments;

public class CommentListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string? InsertDate { get; set; }
    public string? HotelName { get; set; }
    public string? AirlineCompanyName { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public string? TakeOfDate { get; set; }
    public CommentStatus CommentStatus { get; set; }
}
