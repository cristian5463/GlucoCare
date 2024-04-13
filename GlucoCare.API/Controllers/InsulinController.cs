using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using GlucoCare.Domain.Entities;
using GlucoCare.source.Dtos;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System.IdentityModel.Tokens.Jwt;

namespace GlucoCare.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class InsulinController : ControllerBase
{
    private readonly IInsulinService _insulinService;
    private readonly IUserService _userService;
    

    public InsulinController(IInsulinService insulinService, IUserService userService)
    {
        _insulinService = insulinService;
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsulinDTO>>> Get()
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        var insulins = await _insulinService.GetInsulins(user.IdUser);
        return Ok(insulins);
    }

    [HttpGet("{id}", Name = "GetInsulin")]
    public async Task<ActionResult<InsulinDTO>> Get(int id)
    {
        var insulin = await _insulinService.GetById(id);

        if (insulin == null)
        {
            return NotFound();
        }
        return Ok(insulin);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InsulinDTO insulinDTO)
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        insulinDTO.IdUser = user.IdUser;
        insulinDTO.CreatedAt = DateTime.UtcNow;
        await _insulinService.Add(insulinDTO);

        return new CreatedAtRouteResult("GetInsulin",
            new { id = insulinDTO.Id }, insulinDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InsulinDTO insulinDTO)
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        if (id != insulinDTO.Id)
        {
            return BadRequest();
        }

        insulinDTO.IdUser = user.IdUser;
        await _insulinService.Update(insulinDTO);

        return Ok(new Status200<T>("Insulina Alterada"));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<InsulinDTO>> Delete(int id)
    {
        UserDTO user = await _userService.GetUserIdFromToken();

        var insulinDTO = await _insulinService.GetById(id);
        if (insulinDTO == null)
        {
            return NotFound();
        }

        insulinDTO.IdUser = user.IdUser;
        await _insulinService.Remove(id);
        return Ok(new Status200<T>("Insulina Deletada"));
    }
}
