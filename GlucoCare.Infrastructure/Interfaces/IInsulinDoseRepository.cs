using GlucoCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Domain.Interfaces;
public interface IInsulinDoseRepository
{
    Task<IEnumerable<InsulinDoseEntity>> GetInsulinDosesAsync(int idUser);
    Task<InsulinDoseEntity> GetByIdAsync(int? id);
    Task<InsulinDoseEntity> CreateAsync(InsulinDoseEntity insulinDose);
    Task<InsulinDoseEntity> UpdateAsync(InsulinDoseEntity insulinDose);
    Task<InsulinDoseEntity> RemoveAsync(InsulinDoseEntity insulinDose);
}
