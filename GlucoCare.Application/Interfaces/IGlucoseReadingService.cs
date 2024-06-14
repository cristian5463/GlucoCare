using GlucoCare.source.Dtos;

namespace GlucoCare.Application.Interfaces;
public interface IGlucoseReadingService
{
    Task<IEnumerable<GlucoseReadingDTO>> GetGlucoseReadings(int userId);
    Task<GlucoseReadingDTO> GetById(int? id);
    Task Add(GlucoseReadingDTO glucoseReadingDto);
    Task Update(GlucoseReadingDTO glucoseReadingDto);
    Task Remove(int? id);
    Task<decimal> GetSuggestedDose(SuggestedDoseDTO suggestedDoseDto);
}