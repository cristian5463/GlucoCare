using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using GlucoCare.source.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GlucoCare.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class InsulinController : ControllerBase
{
    private readonly IInsulinService _insulinService;

    public InsulinController(IInsulinService insulinService)
    {
        _insulinService = insulinService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InsulinDTO>>> Get()
    {
        var insulins = await _insulinService.GetInsulins();
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        insulinDTO.CreatedAt = DateTime.UtcNow;
        await _insulinService.Add(insulinDTO);

        return new CreatedAtRouteResult("GetInsulin",
            new { id = insulinDTO.Id }, insulinDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] InsulinDTO insulinDTO)
    {
        if (id != insulinDTO.Id)
        {
            return BadRequest();
        }

        await _insulinService.Update(insulinDTO);

        return Ok(new Status200("Insulina Alterada"));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<InsulinDTO>> Delete(int id)
    {
        var insulinDTO = await _insulinService.GetById(id);
        if (insulinDTO == null)
        {
            return NotFound();
        }
        await _insulinService.Remove(id);
        return Ok(new Status200("Insulina Deletada"));
    }
}
