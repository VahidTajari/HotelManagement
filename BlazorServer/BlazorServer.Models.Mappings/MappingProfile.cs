using AutoMapper;
using BlazorServer.Entities;

namespace BlazorServer.Models.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HotelRoomDto, HotelRoom>().ReverseMap(); // two-way mapping
    }
}
