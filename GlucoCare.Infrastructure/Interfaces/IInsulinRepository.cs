using GlucoCare.source.Domain.Entities;

namespace GlucoCare.Domain.Interfaces;
public interface IInsulinRepository
{
    Task<IEnumerable<InsulinEntity>> GetInsulinsAsync(int idUser);
    Task<InsulinEntity> GetByIdAsync(int? id);
    Task<InsulinEntity> CreateAsync(InsulinEntity insulin);
    Task<InsulinEntity> UpdateAsync(InsulinEntity insulin);
    Task<InsulinEntity> RemoveAsync(InsulinEntity insulin);

}
