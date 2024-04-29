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
        var existingConfig = await _configContext.Config
          .Where(c => c.IdUser == config.IdUser)
          .FirstOrDefaultAsync();

        if (existingConfig != null)
        {
            existingConfig.ApplyInsulinSnack = config.ApplyInsulinSnack;
            existingConfig.UseCarbsCalc = config.UseCarbsCalc;
            await _configContext.SaveChangesAsync();
        }
        
        return config;
    }

    public async Task<ConfigEntity> RemoveAsync(ConfigEntity config)
    {
        _configContext.Remove(config);
        await _configContext.SaveChangesAsync();
        return config;
    }
}
