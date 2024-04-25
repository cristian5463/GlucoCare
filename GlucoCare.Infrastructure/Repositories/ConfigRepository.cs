using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore; // Exemplo, ajuste de acordo com seu ORM

namespace GlucoCare.Infrastructure.Repositories;
public class ConfigRepository : IConfigRepository
{
    private readonly DbContext _context;

    public ConfigRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ConfigEntity>> GetConfigAsync(int idUser)
    {
        return await _context.Set<ConfigEntity>()
            .Where(c => c.Id == idUser)
            .ToListAsync();
    }

    public async Task<ConfigEntity> GetByIdAsync(int? id)
    {
        return await _context.Set<ConfigEntity>().FindAsync(id);
    }

    public async Task<ConfigEntity> CreateAsync(ConfigEntity config)
    {
        _context.Add(config);
        await _context.SaveChangesAsync();
        return config;
    }

    public async Task<ConfigEntity> UpdateAsync(ConfigEntity config)
    {
        _context.Entry(config).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return config;
    }

    public async Task<ConfigEntity> RemoveAsync(ConfigEntity config)
    {
        _context.Remove(config);
        await _context.SaveChangesAsync();
        return config;
    }
}
