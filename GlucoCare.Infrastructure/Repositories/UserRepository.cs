using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private ApplicationDbContext _userContext;
    public UserRepository(ApplicationDbContext context)
    {
        _userContext = context;
    }

    public async Task<UserEntity> CreateAsync(UserEntity user, string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        user.PasswordHash = passwordHash;

        _userContext.Add(user);
        await _userContext.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity> GetByUserIdAsync(int? userInt)
    {
        return await _userContext.User.SingleOrDefaultAsync(p => p.UserId == userInt);
    }

    public async Task<UserEntity> RemoveAsync(UserEntity user)
    {
        _userContext.Remove(user);
        await _userContext.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity> UpdateAsync(UserEntity user)
    {
        var existingUser = await _userContext.User.FirstOrDefaultAsync(u => u.UserId == user.UserId);
        //var existingUser = await _userContext.FindAsync<UserEntity>(user.UserId);

        // Define explicitamente quais propriedades devem ser modificadas
        _userContext.Entry(existingUser).CurrentValues.SetValues(user);
        _userContext.Entry(existingUser).Property(x => x.CreatedAt).IsModified = false;

        await _userContext.SaveChangesAsync();

        return existingUser;
    }
}
