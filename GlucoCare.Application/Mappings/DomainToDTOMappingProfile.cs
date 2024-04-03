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
        CreateMap<UserEntity, UserDTO>().ReverseMap();
    }
}
