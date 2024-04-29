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
        private readonly IUserService _userService;
        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService, IUserService userService)
        {
            _configService = configService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ConfigDTO>> Get()
        {
            UserDTO user = await _userService.GetUserIdFromToken();

            try
            {
                var config = await _configService.GetConfig(user.IdUser);
                if (config == null)
                {
                    ConfigDTO configDTO = new ConfigDTO();

                    configDTO.IdUser = user.IdUser;
                    configDTO.ApplyInsulinSnack = false;
                    configDTO.UseCarbsCalc = false;

                    await _configService.Add(configDTO);
                    var newconfig = await _configService.GetConfig(user.IdUser);

                    return Ok(newconfig);
                }

                return Ok(config);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ConfigDTO configDTO)
        {
            UserDTO user = await _userService.GetUserIdFromToken();

            try
            {
                configDTO.IdUser = user.IdUser;
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
            UserDTO user = await _userService.GetUserIdFromToken();

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
