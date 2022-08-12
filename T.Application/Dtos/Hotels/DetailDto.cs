using T.Domain.Hotels;

namespace T.Application.Dtos.Hotels;

public class DetailDto
{
    public int Id { get; set; }
    public string? PersonalName { get; set; }
    public string? PersonalEmail { get; set; }
    public string? PersonalJobTitle { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? CountryCode { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Facebook { get; set; }
    public string? Twitter { get; set; }
    public string? Linkedin { get; set; }
    public int RoomsCount { get; set; }
    public int MaximumRoomPrice { get; set; }
    public int MinimumRoomPrice { get; set; }
    public string? Description { get; set; }
    public MinimumDaysStay MinimumDaysStayValue { get; set; }
    public Housekeeping HousekeepingValue { get; set; }
    public HousekeepingFrequency HousekeepingFrequencyValue { get; set; }
    public Bathroom Bathroom { get; set; }
    public string? Currency { get; set; }
    public List<string> Amenities { get; set; }
    public List<string> ImagesSrc { get; set; }
}
