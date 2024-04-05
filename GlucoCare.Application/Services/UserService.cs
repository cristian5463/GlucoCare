using AutoMapper;
using BCrypt.Net;
using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;

namespace GlucoCare.Application.Services;
public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private UserManager<UserEntity> _userManager;
    private SignInManager<UserEntity> _signInManager;

    public UserService(IMapper mapper, IUserRepository userRepository, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public Task<IdentityResult> Add(UserDTO userDTO)
    {
        var userEntity = _mapper.Map<UserEntity>(userDTO);
        userEntity.UserName = userDTO.Email;
        return _userRepository.CreateAsync(userEntity, userDTO.Password);
    }

    public async Task Remove(int? userId)
    {
        var userEntity = _userRepository.GetByUserIdAsync(userId).Result;
        await _userRepository.RemoveAsync(userEntity);
    }

    public async Task Update(UserDTO userDTO)
    {
        var userEntity = _mapper.Map<UserEntity>(userDTO);
        await _userRepository.UpdateAsync(userEntity);
    }

    public async Task<UserDTO> GetByUserId(int userId)
    {
        var userEntity = await _userRepository.GetByUserIdAsync(userId);
        return _mapper.Map<UserDTO>(userEntity);
    }

    public async Task<UserEntity> Login(LoginDTO loginDTO)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);
        if (!result.Succeeded)
        {
            throw new Exception("Usuário não autenticado");
        }
        return _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDTO.Email.ToUpper());
    }
}
