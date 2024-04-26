using GlucoCare.Domain.Entities;
using GlucoCare.source.Domain.Entities;

namespace GlucoCare.Domain.Interfaces;
public interface IConfigRepository
{
    Task<IEnumerable<ConfigEntity>> GetConfigAsync(int idUser);
    Task<ConfigEntity> GetByIdAsync(int? id);
    Task<ConfigEntity> CreateAsync(ConfigEntity config);
    Task<ConfigEntity> UpdateAsync(ConfigEntity config);
    Task<ConfigEntity> RemoveAsync(ConfigEntity config);
}
