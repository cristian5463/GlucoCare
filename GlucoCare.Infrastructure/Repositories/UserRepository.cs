using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GlucoCare.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private UserDbContext _userContext;
    private UserManager<UserEntity> _userMenager;

    public UserRepository(UserDbContext context, UserManager<UserEntity> userMenager)
    {
        _userContext = context;
        _userMenager = userMenager;
    }

    public async Task<IdentityResult> CreateAsync(UserEntity user, string password)
    {
        try
        {
            IdentityResult result = await _userMenager.CreateAsync(user, password);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
        
    }

    public async Task<UserEntity> GetByUserIdAsync(int? userInt)
    {
        return await _userContext.User.SingleOrDefaultAsync(p => p.IdUser == userInt);
    }

    public async Task<UserEntity> RemoveAsync(UserEntity user)
    {
        _userContext.Remove(user);
        await _userContext.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity> UpdateAsync(UserEntity user)
    {
        var existingUser = await _userContext.Users.FirstOrDefaultAsync(u => u.IdUser == user.IdUser);

        if (existingUser != null)
        {
            // Atualizar as propriedades
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // ... outras propriedades a serem atualizadas

            // Mantendo CreatedAt inalterado
            _userContext.Entry(existingUser).Property(x => x.CreatedAt).IsModified = false;

            await _userContext.SaveChangesAsync();
        }

        return existingUser;
    }
}
