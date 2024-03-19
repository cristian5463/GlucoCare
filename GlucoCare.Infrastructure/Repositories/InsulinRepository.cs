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
        _insulinContext.Update(insulin);
        await _insulinContext.SaveChangesAsync();
        return insulin;
    }
}
