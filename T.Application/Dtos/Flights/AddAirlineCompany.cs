using Microsoft.AspNetCore.Http;

namespace T.Application.Dtos.Flights;

public class AddAirlineCompanyDto : AirlineCompanyListDto
{
    public IFormFile Logo { get; set; }

}

public class AirlineCompanyListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageSrc { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
}

public class EditAirlineCompanyDto : AirlineCompanyListDto
{
    public IFormFile Logo { get; set; }
}
