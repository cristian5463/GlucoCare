using GlucoCare.source.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Interfaces;
public interface IInsulinService
{
    Task<IEnumerable<InsulinDTO>> GetInsulins(int userId);
    Task<InsulinDTO> GetById(int? id);
    Task Add(InsulinDTO insulinDTO);
    Task Update(InsulinDTO insulinDTO);
    Task Remove(int? id);
}
