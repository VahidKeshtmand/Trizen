using T.Application.Dtos.Common;

namespace T.Application.Dtos.Flights;

public class FlightListPageDto
{
    public PaginatedItemsDto<FlightListDto> Flights { get; set; }
    public int AirlineCompanyId { get; set; }
    public string AirlineCompanyName { get; set; }

}


