using GlucoCare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Interfaces;
public interface IInsulinDoseService
{
    Task<IEnumerable<InsulinDoseDTO>> GetInsulinDoses(int idUser);
    Task<InsulinDoseDTO> GetById(int? id);
    Task Add(InsulinDoseDTO insulinDoseDTO);
    Task Update(InsulinDoseDTO insulinDoseDTO);
    Task Remove(int? id);
}
