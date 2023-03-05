using AutoMapper;
using ItemManagement.Application.DataTransferObjects;
using ItemManagement.Domain.Models;

namespace ItemManagement.Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ColorDto, Color>().ReverseMap();
            CreateMap<ItemDto, Item>().ReverseMap();
        }
    }
}