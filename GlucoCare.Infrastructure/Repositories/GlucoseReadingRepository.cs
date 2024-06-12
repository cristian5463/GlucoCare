using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Repositories;

public class GlucoseReadingRepository(ApplicationDbContext applicationDbContext) : IGlucoseReadingRepository
{
    public Task<IEnumerable<GlucoseReadingEntity>> GetGlucoseReadingsAsync(int idUser)
    {
        throw new NotImplementedException();
    }
    
    public async Task<GlucoseReadingEntity> GetByIdAsync(int? id)
    {
        return await applicationDbContext.GlucoseReading.SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<GlucoseReadingEntity> CreateAsync(GlucoseReadingEntity glucoseReading)
    {
        applicationDbContext.Add(glucoseReading);
        await applicationDbContext.SaveChangesAsync();
        return glucoseReading;
    }

    public Task<GlucoseReadingEntity> UpdateAsync(GlucoseReadingEntity glucoseReading)
    {
        throw new NotImplementedException();
    }

    public Task<GlucoseReadingEntity> RemoveAsync(GlucoseReadingEntity glucoseReading)
    {
        throw new NotImplementedException();
    }
}