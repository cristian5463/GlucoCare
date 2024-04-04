using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GlucoCare.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDTO userDTO)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        await _userService.Add(userDTO);
        return Ok(new Status200("Usuário Cadastrado"));
    }

    [HttpPut("{UserId}")]
    public async Task<ActionResult> Put(int userID, [FromBody] UserDTO userDTO)
    {
        if (userID != userDTO.UserId)
        {
            return BadRequest();
        }

        await _userService.Update(userDTO);

        return Ok(new Status200("Usuário Alterado"));
    }

    [HttpDelete("{UserId}")]
    public async Task<ActionResult<UserDTO>> Delete(int userId)
    {
        var userDTO = await _userService.GetByUserId(userId);
        if (userDTO == null)
        {
            return Ok(new Status400("Usuário Não Encontrado"));
        }
        await _userService.Remove(userId);
        return Ok(new Status200("Usuário Deletado"));
    }
}
