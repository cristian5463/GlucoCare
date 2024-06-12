using AutoMapper;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Interfaces;
using GlucoCare.source.Domain.Entities;
using GlucoCare.source.Dtos;

namespace GlucoCare.Application.Services;
public class InsulinService(IMapper mapper, IInsulinRepository insulinRepository) : IInsulinService
{
    private readonly IInsulinRepository _insulinRepository = insulinRepository ?? 
                                                             throw new ArgumentNullException(nameof(insulinRepository));

    public Task Add(InsulinDTO insulinDTO)
    {
        var insulinEntity = mapper.Map<InsulinEntity>(insulinDTO);
        return _insulinRepository.CreateAsync(insulinEntity);
    }

    public async Task<InsulinDTO> GetById(int? id)
    {
        var insulinEntity = await _insulinRepository.GetByIdAsync(id);
        return mapper.Map<InsulinDTO>(insulinEntity);
    }

    public async Task<IEnumerable<InsulinDTO>> GetInsulins(int idUser)
    {
        var insulinEntity = await _insulinRepository.GetInsulinsAsync(idUser);
        return mapper.Map<IEnumerable<InsulinDTO>>(insulinEntity);
    }

    public async Task Remove(int? id)
    {
        var insulinEntity = _insulinRepository.GetByIdAsync(id).Result;
        await _insulinRepository.RemoveAsync(insulinEntity);
    }

    public async Task Update(InsulinDTO insulinDTO)
    {
        var insulinEntity = mapper.Map<InsulinEntity>(insulinDTO);
        await _insulinRepository.UpdateAsync(insulinEntity);
    }
}
