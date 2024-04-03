using GlucoCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Domain.Interfaces;
public interface IUserRepository
{
    Task<UserEntity> CreateAsync(UserEntity user, string password);
    Task<UserEntity> UpdateAsync(UserEntity user);
    Task<UserEntity> RemoveAsync(UserEntity user);
}
