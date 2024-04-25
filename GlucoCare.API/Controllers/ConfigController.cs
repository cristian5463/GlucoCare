using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Services;
using GlucoCare.source.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlucoCare.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet("{id}", Name = "GetConfig")]
        public async Task<ActionResult<ConfigDTO>> Get(int id)
        {
            try
            {
                var config = await _configService.GetById(id);
                if (config == null)
                {
                    return NotFound("Configuração não encontrada!");
                }
                return Ok(config);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ConfigDTO>> Post([FromBody] ConfigDTO configDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _configService.Add(configDTO);
                return CreatedAtAction(nameof(Get), new { id = configDTO.Id }, configDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ConfigDTO configDTO)
        {
            if (id != configDTO.Id)
            {
                return BadRequest("O ID fornecido não corresponde ao ID do objeto.");
            }

            try
            {
                await _configService.Update(configDTO);
                return Ok("Configuração alterada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _configService.Remove(id);
                return Ok("Configuração deletada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
