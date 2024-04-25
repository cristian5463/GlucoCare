using GlucoCare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Interfaces
{
    public interface IConfigService
    {
        Task<ConfigDTO> GetById(int? id);
        Task Add(ConfigDTO ConfigDTO);
        Task Update(ConfigDTO ConfigDTO);
        Task Remove(int? id);
    }
}
