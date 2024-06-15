using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GlucoCare.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class InsulinDoseController : ControllerBase
{
    private readonly IInsulinDoseService _insulinDoseService;
    private readonly IUserService _userService;
    
    public InsulinDoseController(IInsulinDoseService insulinDoseService, IUserService userService)
    {
        _insulinDoseService = insulinDoseService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsulinDoseDTO>>> Get()
    {
        UserDTO user = await _userService.GetUserIdFromToken();
        try
        {
            var insulinDoses = await _insulinDoseService.GetInsulinDoses(user.IdUser);

            return Ok(insulinDoses);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet("{id}", Name = "GetInsulinDose")]
    public async Task<ActionResult<InsulinDoseDTO>> Get(int id)
    {
        try
        {
            var insulinDose = await _insulinDoseService.GetById(id);

            if (insulinDose == null)
            {
                return NotFound("Insulina não encontrada!");
            }

            return Ok(insulinDose);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetByIdTypeInsulin/{idTypeInsulin}", Name = "GetByIdTypeInsulin")]
    public async Task<ActionResult<IEnumerable<InsulinDoseDTO>>> GetByIdTypeInsulin(int idTypeInsulin)
    {
        try
        {
            var insulinDose = await _insulinDoseService.GetByIdTypeInsulin(idTypeInsulin);

            if (insulinDose == null)
            {
                return NotFound("Insulina não encontrada!");
            }

            return Ok(insulinDose);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] InsulinDoseDTO insulinDoseDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            insulinDoseDTO.CreatedAt = DateTime.UtcNow;
            await _insulinDoseService.Add(insulinDoseDTO);

            return new CreatedAtRouteResult("GetInsulinDose",
                new { id = insulinDoseDTO.Id }, insulinDoseDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InsulinDoseDTO insulinDTO)
    {
        if (id != insulinDTO.Id)
        {
            return BadRequest();
        }

        await _insulinDoseService.Update(insulinDTO);

        return Ok("Dose de Insulina Alterada");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<InsulinDoseDTO>> Delete(int id)
    {
        var insulinDTO = await _insulinDoseService.GetById(id);
        if (insulinDTO == null)
        {
            return NotFound();
        }

        await _insulinDoseService.Remove(id);
        return Ok("Dose de Insulina Deletada");
    }
}
