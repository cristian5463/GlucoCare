using AutoMapper;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Repositories;
using GlucoCare.source.Dtos;

namespace GlucoCare.Application.Services;

public class GlucoseReadingService(IMapper mapper, IGlucoseReadingRepository glucoseReadingRepository) : IGlucoseReadingService
{
    public async Task<IEnumerable<GlucoseReadingDTO>> GetGlucoseReadings(int userId)
    {
        var glucoseReading = await glucoseReadingRepository.GetGlucoseReadingsAsync(userId);
        return mapper.Map<IEnumerable<GlucoseReadingDTO>>(glucoseReading);
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

    public async Task Update(GlucoseReadingDTO glucoseReadingDto)
    {
        var glucoseReading = mapper.Map<GlucoseReadingEntity>(glucoseReadingDto);
        await glucoseReadingRepository.UpdateAsync(glucoseReading);
    }

    public async Task Remove(int? id)
    {
        var glucoseReadingEntity = glucoseReadingRepository.GetByIdAsync(id).Result;
        await glucoseReadingRepository.RemoveAsync(glucoseReadingEntity);
    }

    public Task GetSuggestedDose(int idInsulin, int valueGlucose)
    {
        throw new NotImplementedException();
    }
}