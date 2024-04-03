using AutoMapper;
using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;

namespace GlucoCare.Application.Services;
public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _userRepository = userRepository ??
            throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper;
    }
    public Task Add(UserDTO userDTO)
    {
        var userEntity = _mapper.Map<UserEntity>(userDTO);
        return _userRepository.CreateAsync(userEntity, userDTO.Password);
    }

    public async Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(UserDTO userDTO)
    {
        var userEntity = _mapper.Map<UserEntity>(userDTO);
        await _userRepository.UpdateAsync(userEntity);
    }
}
