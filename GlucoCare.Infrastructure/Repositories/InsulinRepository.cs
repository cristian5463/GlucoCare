using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Repositories;
public class InsulinRepository : IInsulinRepository
{
    private ApplicationDbContext _insulinContext;

    public InsulinRepository(ApplicationDbContext context)
    {
        _insulinContext = context;
    }
    public async Task<InsulinEntity> CreateAsync(InsulinEntity insulin)
    {
        _insulinContext.Add(insulin);
        await _insulinContext.SaveChangesAsync();
        return insulin;
    }

    public async Task<InsulinEntity> RemoveAsync(InsulinEntity insulin)
    {
        _insulinContext.Remove(insulin);
        await _insulinContext.SaveChangesAsync();
        return insulin;
    }

    public async Task<InsulinEntity> GetByIdAsync(int? id)
    {
        return await _insulinContext.Insulin.SingleOrDefaultAsync(p => p.Id == id);

    }

    public async Task<IEnumerable<InsulinEntity>> GetInsulinsAsync()
    {
        return await _insulinContext.Insulin.ToListAsync();
    }

    public async Task<InsulinEntity> UpdateAsync(InsulinEntity insulin)
    {
        var existingInsulin = await _insulinContext.FindAsync<InsulinEntity>(insulin.Id);

        // Define explicitamente quais propriedades devem ser modificadas
        _insulinContext.Entry(existingInsulin).CurrentValues.SetValues(insulin);
        _insulinContext.Entry(existingInsulin).Property(x => x.CreatedAt).IsModified = false;

        await _insulinContext.SaveChangesAsync();

        return existingInsulin;
    }
}
