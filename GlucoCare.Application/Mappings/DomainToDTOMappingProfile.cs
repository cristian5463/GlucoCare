using GlucoCare.source.Domain.Entities;
using GlucoCare.source.Dtos;
using AutoMapper;
using GlucoCare.Domain.Entities;
using GlucoCare.Application.DTOs;

namespace GlucoCare.Application.Mappings;
public class DomainToDTOMappingProfile :Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<InsulinEntity, InsulinDTO>().ReverseMap();
        CreateMap<InsulinDoseEntity, InsulinDoseDTO>().ReverseMap();
        CreateMap<UserEntity, UserDTO>().ReverseMap();
        CreateMap<ConfigEntity, ConfigDTO>().ReverseMap();
        CreateMap<UserUpdateEntity, UserUpdateDTO>().ReverseMap();
        CreateMap<GlucoseReadingEntity, GlucoseReadingDTO>().ReverseMap();
        CreateMap<SuggestedDoseDTO, SuggestedDoseDTO>().ReverseMap();
    }
}
