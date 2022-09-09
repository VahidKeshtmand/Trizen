using T.Domain.Hotels;

namespace T.Application.Dtos.Hotels;

public class ListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
}