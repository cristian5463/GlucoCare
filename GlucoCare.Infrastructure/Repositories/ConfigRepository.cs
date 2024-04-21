using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlucoCare.Infrastructure.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly ApplicationDbContext _configContext;

        public ConfigRepository(ApplicationDbContext context)
        {
            _configContext = context;
        }

        public async Task<ConfigEntity> CreateAsync(ConfigEntity config)
        {
            _configContext.Add(config);
            await _configContext.SaveChangesAsync();
            return config;
        }

        public async Task<ConfigEntity> RemoveAsync(ConfigEntity config)
        {
            _configContext.Remove(config);
            await _configContext.SaveChangesAsync();
            return config;
        }

        public async Task<ConfigEntity> GetByIdAsync(int? id)
        {
            return await _configContext.Config.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ConfigEntity>> GetAllAsync()
        {
            return await _configContext.Config.ToListAsync();
        }

        public async Task<ConfigEntity> UpdateAsync(ConfigEntity config)
        {
            var existingConfig = await _configContext.FindAsync<ConfigEntity>(config.Id);

            _configContext.Entry(existingConfig).CurrentValues.SetValues(config);
            _configContext.Entry(existingConfig).Property(x => x.CreatedAt).IsModified = false;

            await _configContext.SaveChangesAsync();

            return existingConfig;
        }
    }
}
