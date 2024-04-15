using AutoMapper;
using BCrypt.Net;
using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace GlucoCare.Application.Services;
public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private UserManager<UserEntity> _userManager;
    private SignInManager<UserEntity> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IMapper mapper, IUserRepository userRepository, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
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

    public async Task<UserDTO> GetUserIdFromToken()
    {
        try
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
            {
                throw new Exception("Não foi possível acessar o contexto da requisição.");
            }

            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Decodificar o token JWT (mesma lógica anterior)
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims;

            var userIdClaim = claims.First(c => c.Type == "idUser");
            var emailClaim = claims.FirstOrDefault(c => c.Type == "email");
            var nameClaim = claims.FirstOrDefault(c => c.Type == "name");

            return new UserDTO
            {
                IdUser = Convert.ToInt32(userIdClaim.Value),
                Email = emailClaim.Value,
                Name = nameClaim.Value
            };
        }
        catch (Exception)
        {
            throw new Exception("Usuário não conectado!");
        }
        
    }
}
