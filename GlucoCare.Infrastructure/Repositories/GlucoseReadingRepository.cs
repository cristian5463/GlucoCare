using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Repositories;

public class GlucoseReadingRepository(ApplicationDbContext applicationDbContext) : IGlucoseReadingRepository
{
    public async Task<IEnumerable<GlucoseReadingEntity>> GetGlucoseReadingsAsync(int idUser)
    {
        return await applicationDbContext.GlucoseReading.Where(x => x.IdUser == idUser).ToListAsync();
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

    public async Task<GlucoseReadingEntity> UpdateAsync(GlucoseReadingEntity glucoseReading)
    {
        var existingReading = await applicationDbContext.FindAsync<GlucoseReadingEntity>(glucoseReading.Id);

        // Define explicitamente quais propriedades devem ser modificadas
        applicationDbContext.Entry(existingReading).CurrentValues.SetValues(glucoseReading);
        applicationDbContext.Entry(existingReading).Property(x => x.CreatedAt).IsModified = false;

        await applicationDbContext.SaveChangesAsync();

        return existingReading;
    }

    public async Task<GlucoseReadingEntity> RemoveAsync(GlucoseReadingEntity glucoseReading)
    {
        applicationDbContext.Remove(glucoseReading);
        await applicationDbContext.SaveChangesAsync();
        return glucoseReading;
    }
}