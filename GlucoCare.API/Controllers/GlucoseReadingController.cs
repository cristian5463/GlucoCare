using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using GlucoCare.Application.Services;
using GlucoCare.source.Dtos;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;

namespace GlucoCare.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]

public class GlucoseReadingController(
    IUserService userService, 
    IGlucoseReadingService glucoseReadingService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsulinDTO>>> Get()
    {
        UserDTO user = await userService.GetUserIdFromToken();

        var glucoseReading = await glucoseReadingService.GetGlucoseReadings(user.IdUser);
        return Ok(glucoseReading);
    }

    [HttpGet("{id}", Name = "GetGlucoseReading")]
    public async Task<ActionResult<InsulinDTO>> Get(int id)
    {
        try
        {
            var glucoseReading = await glucoseReadingService.GetById(id);

            return Ok(glucoseReading);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] GlucoseReadingDTO glucoseReading)
    {
        UserDTO user = await userService.GetUserIdFromToken();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            glucoseReading.IdUser = user.IdUser;
            glucoseReading.CreatedAt = DateTime.UtcNow;
            await glucoseReadingService.Add(glucoseReading);

            return new CreatedAtRouteResult("GetGlucoseReading",
                new { id = glucoseReading.Id }, glucoseReading);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /*[HttpPut("{id}")]
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
    }*/
}