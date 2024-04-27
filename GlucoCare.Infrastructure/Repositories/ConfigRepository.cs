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

    public async Task<ConfigEntity> GetConfigAsync(int idUser)
    {
        return await _configContext.Set<ConfigEntity>()
            .FirstOrDefaultAsync(c => c.IdUser == idUser);
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
