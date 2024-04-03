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
        await _userService.Update(userDTO);

        return Ok(new Status200("Usuário Alterado"));
    }
}
