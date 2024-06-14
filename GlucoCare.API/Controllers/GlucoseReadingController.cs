using GlucoCare.API.Response;
using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using GlucoCare.Application.Services;
using GlucoCare.source.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
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
        UserDTO user = await userService.GetUserIdFromToken();

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

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] GlucoseReadingDTO glucoseReading)
    {
        try
        {
            UserDTO user = await userService.GetUserIdFromToken();

            if (id != glucoseReading.Id)
            {
                return BadRequest();
            }
            
            glucoseReading.IdUser = user.IdUser;
            await glucoseReadingService.Update(glucoseReading);

            return Ok("Leitura alterada");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<InsulinDTO>> Delete(int id)
    {
        UserDTO user = await userService.GetUserIdFromToken();

        var glucoseReadingDto = await glucoseReadingService.GetById(id);

        glucoseReadingDto.IdUser = user.IdUser;
        await glucoseReadingService.Remove(id);
        return Ok("Leitura deletada!");
    }

    [HttpPost("CalculateSuggestedDose")]
    public async Task<IActionResult> GetSuggestedDose([FromBody] SuggestedDoseDTO suggestedDoseDto)
    {
        try
        {
            UserDTO user = await userService.GetUserIdFromToken();

            suggestedDoseDto.IdUser = user.IdUser;
            var suggestedDose = await glucoseReadingService.GetSuggestedDose(suggestedDoseDto);

            return Ok(new SuggestedDoseResponse()
            {
                SuggestedDose = suggestedDose,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new SuggestedDoseResponse()
            {
                SuggestedDose = 0,
                StatusCode = 400,
                Error = ex.Message
            });
        }
    }
}