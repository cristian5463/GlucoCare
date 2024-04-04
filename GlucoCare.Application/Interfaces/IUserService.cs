using GlucoCare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Interfaces;
public interface IUserService
{
    Task Add(UserDTO userDTO);
    Task Update(UserDTO userDTO);
    Task Remove(int? id);
    Task<UserDTO> GetByUserId(int userId);
}
