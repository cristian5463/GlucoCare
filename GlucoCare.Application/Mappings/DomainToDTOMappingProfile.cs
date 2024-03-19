using GlucoCare.source.Domain.Entities;
using GlucoCare.source.Dtos;
using AutoMapper;

namespace GlucoCare.Application.Mappings;
public class DomainToDTOMappingProfile :Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<InsulinEntity, InsulinDTO>().ReverseMap();
    }
}
