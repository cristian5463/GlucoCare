using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using GlucoCare.Application.Services.Tokens;
using GlucoCare.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;

namespace GlucoCare.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private TokenService _tokenService;

    public UserController(IUserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        IdentityResult result = await _userService.Add(userDTO);

        if (!result.Succeeded)
        {
            return BadRequest(new Status400("Usuário Não Cadastrado"));
        }

        return Ok(new Status200<T>("Usuário Cadastrado"));
    }

    [HttpPut("{UserId}")]
    public async Task<ActionResult> Put(int userID, [FromBody] UserDTO userDTO)
    {
        if (userID != userDTO.IdUser)
        {
            return BadRequest();
        }

        await _userService.Update(userDTO);

        return Ok(new Status200<T>("Usuário Alterado"));
    }

    [HttpDelete("{UserId}")]
    public async Task<ActionResult<UserDTO>> Delete(int userId)
    {
        var userDTO = await _userService.GetByUserId(userId);
        if (userDTO == null)
        {
            return BadRequest(new Status400("Usuário Não Encontrado"));
        }
        await _userService.Remove(userId);
        return Ok(new Status200<T>("Usuário Deletado"));
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _userService.Login(loginDTO);
            var token = _tokenService.GenerateToken(user);

            var userEntity = new UserEntity();

            Status200<string> statusInsulin = new("Usuário autenticado.", token);

            return Ok(statusInsulin);
        }
        catch (Exception ex)
        {
            return BadRequest(new Status400(ex.Message));
        }
    }
}
