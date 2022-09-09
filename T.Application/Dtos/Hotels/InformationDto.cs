using T.Application.Dtos.Common;

namespace T.Application.Dtos.Hotels;

public class InformationDto
{
    public List<CountryNameDto>? CountriesName { get; set; } = new();
    public List<CountryCodeDto>? CountriesCode { get; set; } = new();
    public List<CurrencyDto>? Currencies { get; set; } = new();
    public List<AmenityDto>? Amenities { get; set; } = new();
}
