using GlucoCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Domain.Interfaces;
public interface IUserRepository
{
    Task<IdentityResult> CreateAsync(UserEntity user, string password);
    Task<UserEntity> UpdateAsync(UserUpdateEntity user);
    Task<UserEntity> RemoveAsync(UserEntity user);
    Task<UserEntity> GetByUserIdAsync(int? userInt);
}
