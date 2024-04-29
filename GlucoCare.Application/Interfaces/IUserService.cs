using GlucoCare.Application.DTOs;
using GlucoCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GlucoCare.Application.Interfaces;
public interface IUserService
{
    Task<IdentityResult> Add(UserDTO userDTO);
    Task Update(UserUpdateDTO userDTO);
    Task Remove(int? id);
    Task<UserDTO> GetByUserId(int userId);
    Task<UserEntity> Login(LoginDTO loginDTO);
    Task<UserDTO> GetUserIdFromToken();
}
