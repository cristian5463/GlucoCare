using AutoMapper;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Repositories;
using GlucoCare.source.Dtos;

namespace GlucoCare.Application.Services;

public class GlucoseReadingService(IMapper mapper, IGlucoseReadingRepository glucoseReadingRepository) : IGlucoseReadingService
{
    public Task<IEnumerable<GlucoseReadingDTO>> GetGlucoseReadings(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<GlucoseReadingDTO> GetById(int? id)
    {
        var glucoseReadingEntity = await glucoseReadingRepository.GetByIdAsync(id);
        return mapper.Map<GlucoseReadingDTO>(glucoseReadingEntity);
    }

    public Task Add(GlucoseReadingDTO glucoseReadingDto)
    {
        var glucoseReadingEntity = mapper.Map<GlucoseReadingEntity>(glucoseReadingDto);
        return glucoseReadingRepository.CreateAsync(glucoseReadingEntity);
    }

    public Task Update(GlucoseReadingDTO glucoseReadingDto)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public Task GetSuggestedDose(int idInsulin, int valueGlucose)
    {
        throw new NotImplementedException();
    }
}