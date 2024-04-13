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
public class InsulinDoseService : IInsulinDoseService
{
    private IInsulinDoseRepository _insulinDoseRepository;
    private readonly IMapper _mapper;

    public InsulinDoseService (IMapper mapper, IInsulinDoseRepository insulinDoseRepository)
    {
        _insulinDoseRepository = insulinDoseRepository ??
            throw new ArgumentNullException(nameof(insulinDoseRepository));
        _mapper = mapper;
    }

    public Task Add(InsulinDoseDTO insulinDoseDTO)
    {
        var insulinDoseEntity = _mapper.Map<InsulinDoseEntity>(insulinDoseDTO);
        return _insulinDoseRepository.CreateAsync(insulinDoseEntity);
    }

    public async Task<InsulinDoseDTO> GetById(int? id)
    {
        var insulinDoseEntity = await _insulinDoseRepository.GetByIdAsync(id);
        return _mapper.Map<InsulinDoseDTO>(insulinDoseEntity);
    }

    public async Task<IEnumerable<InsulinDoseDTO>> GetInsulinDoses(int idUser)
    {
        var insulinDoseEntity = await _insulinDoseRepository.GetInsulinDosesAsync(idUser);
        return _mapper.Map<IEnumerable<InsulinDoseDTO>>(insulinDoseEntity);
    }

    public async Task Remove(int? id)
    {
        var insulinDoseEntity = _insulinDoseRepository.GetByIdAsync(id).Result;
        await _insulinDoseRepository.RemoveAsync(insulinDoseEntity);
    }

    public async Task Update(InsulinDoseDTO insulinDoseDTO)
    {
        var insulinDoseEntity = _mapper.Map<InsulinDoseEntity>(insulinDoseDTO);
        await _insulinDoseRepository.UpdateAsync(insulinDoseEntity);
    }
}
