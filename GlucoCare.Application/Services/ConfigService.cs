using AutoMapper;
using GlucoCare.Application.DTOs;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Services;
public class ConfigService : IConfigService
{
    private IConfigRepository _configRepository;
    private readonly IMapper _mapper;

    public ConfigService (IMapper mapper, IConfigRepository configRepository)
    {
        _configRepository = configRepository ??
            throw new ArgumentNullException(nameof(configRepository));
        _mapper = mapper;
    }

    public async Task Add(ConfigDTO configDTO)
    {
        var configEntity = _mapper.Map<ConfigEntity>(configDTO);
        await _configRepository.CreateAsync(configEntity);
    }

    public async Task<ConfigDTO> GetById(int? id)
    {
        var configEntity = await _configRepository.GetByIdAsync(id);
        return _mapper.Map<ConfigDTO>(configEntity);
    }

    public async Task<IEnumerable<ConfigDTO>> GetAll()
    {
        var configEntity = await _configRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ConfigDTO>>(configEntity);
    }

    public async Task Remove(int? id)
    {
        var configEntity = await _configRepository.GetByIdAsync(id);
        if (configEntity != null)
            await _configRepository.RemoveAsync(configEntity);
    }

    public async Task Update(ConfigDTO configDTO)
    {
        var configEntity = _mapper.Map<ConfigEntity>(configDTO);
        await _configRepository.UpdateAsync(configEntity);
    }
}