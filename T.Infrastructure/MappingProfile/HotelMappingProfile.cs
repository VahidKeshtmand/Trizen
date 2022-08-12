using AutoMapper;
using T.Application.Dtos.Hotels;
using T.Domain.Hotels;

namespace T.Infrastructure.MappingProfile
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile()
        {
            // CreateMap<RegisterHotelDto, Hotel>().ReverseMap();
        }
    }
}
