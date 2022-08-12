namespace T.Website.Endpoint.Models.Comments;

public class AddCommentViewModel
{
    public int ServiceRate { get; set; }
    public int LocationRate { get; set; }
    public int FacilityRate { get; set; }
    public int ValueForMoneyService { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public int HotelId { get; set; }
    public int UserId { get; set; }

}
