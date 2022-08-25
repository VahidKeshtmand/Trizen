using T.Application.Dtos.Common;
using T.Application.Dtos.Hotels;

namespace T.Application.Dtos.Flights;

public class InformationForAddFlightDto
{
    public List<CurrencyDto>? Currencies { get; set; } = new();
    public List<AmenityDto>? Amenities { get; set; } = new();
}
