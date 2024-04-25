using AutoMapper;
using GlucoCare.Application.DTOs;
using GlucoCare.source.Dtos;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlucoCare.Application.Services;
public class ConfigService : IConfigService
{
    private IConfigRepository _configRepository;
    private IMapper _mapper;

    public ConfigService(IMapper mapper, IConfigRepository configRepository)
    {
        _configRepository = configRepository ?? 
            throw new ArgumentNullException(nameof(configRepository));
        _mapper = mapper;
    }

    public Task Add(ConfigDTO configDTO)
    {
        var configEntity = _mapper.Map<ConfigEntity>(configDTO);
        return _configRepository.CreateAsync(configEntity);
    }

    public async Task<ConfigDTO> GetById(int? id)
    {
        var configEntity = await _configRepository.GetByIdAsync(id);
        return _mapper.Map<ConfigDTO>(configEntity);
    }

    public async Task<IEnumerable<ConfigDTO>> GetAll()
    {
        var configEntities = await _configRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ConfigDTO>>(configEntities);
    }

    public async Task Remove(int? id)
    {
        var configEntity = await _configRepository.GetByIdAsync(id).Result;
        await _configRepository.RemoveAsync(configEntity);
        
    }

    public async Task Update(ConfigDTO configDTO)
    {
        var configEntity = _mapper.Map<ConfigEntity>(configDTO);
        await _configRepository.UpdateAsync(configEntity);
    }
}
