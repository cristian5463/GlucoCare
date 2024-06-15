using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Repositories;
public class InsulinDoseRepository : IInsulinDoseRepository
{
    private ApplicationDbContext _insulinDoseContext;
    public InsulinDoseRepository(ApplicationDbContext context) 
    {
        _insulinDoseContext = context;
    }
    public async Task<InsulinDoseEntity> CreateAsync(InsulinDoseEntity insulinDose)
    {
        _insulinDoseContext.Add(insulinDose);
        await _insulinDoseContext.SaveChangesAsync();
        return insulinDose;
    }

    public async Task<InsulinDoseEntity> GetByIdAsync(int? id)
    {
        return await _insulinDoseContext.InsulinDose.SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<InsulinDoseEntity>> GetByIdTypeInsulinAsync(int? idTypeInsulin)
    {
        var dosesOfInsulin = await _insulinDoseContext.InsulinDose
            .Where(x => x.IdTypeInsulin == idTypeInsulin)
            .ToListAsync();

        return dosesOfInsulin;
    }

    public async Task<IEnumerable<InsulinDoseEntity>> GetInsulinDosesAsync(int idUser)
    {
        //return await _insulinDoseContext.InsulinDose.Where(x => x.IdUser == idUser).ToListAsync();
        // Definindo o join entre as tabelas
        var dosesOfInsulin = await _insulinDoseContext.InsulinDose
            .Join(_insulinDoseContext.Insulin,
                dose => dose.IdTypeInsulin,
                insulin => insulin.Id,
                (dose, insulin) => new { Dose = dose, Insulin = insulin })
            .Where(x => x.Insulin.IdUser == idUser)
            .Select(x => x.Dose)
            .ToListAsync();

        return dosesOfInsulin;
    }

    public async Task<InsulinDoseEntity> RemoveAsync(InsulinDoseEntity insulinDose)
    {
        _insulinDoseContext.Remove(insulinDose);
        await _insulinDoseContext.SaveChangesAsync();
        return insulinDose;
    }

    public async Task<InsulinDoseEntity> UpdateAsync(InsulinDoseEntity insulinDose)
    {
        var existingInsulin = await _insulinDoseContext.FindAsync<InsulinDoseEntity>(insulinDose.Id);

        // Define explicitamente quais propriedades devem ser modificadas
        _insulinDoseContext.Entry(existingInsulin).CurrentValues.SetValues(insulinDose);
        _insulinDoseContext.Entry(existingInsulin).Property(x => x.CreatedAt).IsModified = false;

        await _insulinDoseContext.SaveChangesAsync();

        return existingInsulin;
    }
}
