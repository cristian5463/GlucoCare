using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Response;
using GlucoCare.Domain.Entities;
using GlucoCare.source.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GlucoCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet("{id}")]
        public ActionResult<ConfigDto> GetConfigById(int id)
        {
            var config = _configService.GetConfigById(id);
            if (config == null)
            {
                return NotFound();
            }
            return Ok(config);
        }

        [HttpPost]
        public ActionResult<ConfigDto> CreateConfiguration([FromBody] ConfigDto configDto)
        {
            var createdConfig = _configService.CreateConfiguration(configDto);
            return CreatedAtAction(nameof(GetConfigById), new { id = createdConfig.Id }, createdConfig);
        }

        [HttpPut("{id}")]
        public ActionResult<ConfigDto> UpdateConfiguration(int id, [FromBody] ConfigDto configDto)
        {
            var updatedConfig = _configService.UpdateConfiguration(id, configDto);
            if (updatedConfig == null)
            {
                return NotFound();
            }
            return Ok(updatedConfig);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteConfiguration(int id)
        {
            var config = _configService.GetConfigurationById(id);
            if (config == null)
            {
                return NotFound();
            }

            _configService.DeleteConfiguration(id);
            return NoContent();
        }
    }
}