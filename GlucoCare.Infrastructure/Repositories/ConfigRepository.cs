using GlucoCare.Domain.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Infrastructure.Context;
using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Repositories;
public class ConfigRepository : IConfigRepository
{
    private ApplicationDbContext _configContext;

    public ConfigRepository(ApplicationDbContext context)
    {
        _configContext = context;
    }

    public async Task<IEnumerable<ConfigEntity>> GetConfigAsync(int idUser)
    {
        return await _configContext.Set<ConfigEntity>()
            .Where(c => c.Id == idUser)
            .ToListAsync();
    }

    public async Task<ConfigEntity> GetByIdAsync(int? id)
    {
        return await _configContext.Set<ConfigEntity>().FindAsync(id);
    }

    public async Task<ConfigEntity> CreateAsync(ConfigEntity config)
    {
        _configContext.Add(config);
        await _configContext.SaveChangesAsync();
        return config;
    }

    public async Task<ConfigEntity> UpdateAsync(ConfigEntity config)
    {
        _configContext.Entry(config).State = EntityState.Modified;
        await _configContext.SaveChangesAsync();
        return config;
    }

    public async Task<ConfigEntity> RemoveAsync(ConfigEntity config)
    {
        _configContext.Remove(config);
        await _configContext.SaveChangesAsync();
        return config;
    }
}
