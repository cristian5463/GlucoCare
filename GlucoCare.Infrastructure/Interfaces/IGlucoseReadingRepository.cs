using GlucoCare.Domain.Entities;

namespace GlucoCare.Domain.Interfaces;

public interface IGlucoseReadingRepository
{
    Task<IEnumerable<GlucoseReadingEntity>> GetGlucoseReadingsAsync(int idUser);
    Task<GlucoseReadingEntity> GetByIdAsync(int? id);
    Task<GlucoseReadingEntity> CreateAsync(GlucoseReadingEntity glucoseReading);
    Task<GlucoseReadingEntity> UpdateAsync(GlucoseReadingEntity glucoseReading);
    Task<GlucoseReadingEntity> RemoveAsync(GlucoseReadingEntity glucoseReading);
}