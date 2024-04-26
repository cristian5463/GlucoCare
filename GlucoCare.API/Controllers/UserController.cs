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

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UserDTO userDTO)
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        try
        {
            userDTO.IdUser = user.IdUser;

            await _userService.Update(userDTO);

            var newUserDTO = await _userService.GetByUserId(user.IdUser);

            Status200<UserDTO> statusUser = new("Usuário alterado.", newUserDTO);

            return Ok(statusUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new Status400("Não foi possível atualizar o cadastros. - " + ex.Message));
        }
        
    }

    [HttpDelete]
    public async Task<ActionResult<UserDTO>> Delete()
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        var userDTO = await _userService.GetByUserId(user.IdUser);
        if (userDTO == null)
        {
            return BadRequest(new Status400("Usuário Não Encontrado"));
        }
        await _userService.Remove(user.IdUser);
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

    [HttpGet]
    public async Task<ActionResult<UserDTO>> Get()
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        var userDTO = await _userService.GetByUserId(user.IdUser);
        if (userDTO == null)
        {
            return NotFound("Usuário Não Encontrado");
        }
        return Ok(userDTO);
    }
}
