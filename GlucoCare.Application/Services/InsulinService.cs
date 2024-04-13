using AutoMapper;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Interfaces;
using GlucoCare.source.Domain.Entities;
using GlucoCare.source.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Services;
public class InsulinService : IInsulinService
{
    private IInsulinRepository _insulinRepository;
    private readonly IMapper _mapper;

    public InsulinService(IMapper mapper, IInsulinRepository insulinRepository)
    {
        _insulinRepository = insulinRepository ?? 
            throw new ArgumentNullException(nameof(insulinRepository));
        _mapper = mapper;
    }
    public Task Add(InsulinDTO insulinDTO)
    {
        var insulinEntity = _mapper.Map<InsulinEntity>(insulinDTO);
        return _insulinRepository.CreateAsync(insulinEntity);
    }

    public async Task<InsulinDTO> GetById(int? id)
    {
        var insulinEntity = await _insulinRepository.GetByIdAsync(id);
        return _mapper.Map<InsulinDTO>(insulinEntity);
    }

    public async Task<IEnumerable<InsulinDTO>> GetInsulins(int idUser)
    {
        var insulinEntity = await _insulinRepository.GetInsulinsAsync(idUser);
        return _mapper.Map<IEnumerable<InsulinDTO>>(insulinEntity);
    }

    public async Task Remove(int? id)
    {
        var insulinEntity = _insulinRepository.GetByIdAsync(id).Result;
        await _insulinRepository.RemoveAsync(insulinEntity);
    }

    public async Task Update(InsulinDTO insulinDTO)
    {
        var insulinEntity = _mapper.Map<InsulinEntity>(insulinDTO);
        await _insulinRepository.UpdateAsync(insulinEntity);
    }
}
