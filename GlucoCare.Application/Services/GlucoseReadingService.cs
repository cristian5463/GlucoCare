using AutoMapper;
using GlucoCare.Application.Interfaces;
using GlucoCare.Domain.Entities;
using GlucoCare.Domain.Interfaces;
using GlucoCare.source.Dtos;

namespace GlucoCare.Application.Services;

public class GlucoseReadingService(
    IMapper mapper, 
    IGlucoseReadingRepository glucoseReadingRepository, 
    IInsulinRepository insulinRepository,
    IInsulinDoseRepository insulinDoseRepository) : IGlucoseReadingService
{
    public async Task<IEnumerable<GlucoseReadingDTO>> GetGlucoseReadings(int userId)
    {
        var glucoseReading = await glucoseReadingRepository.GetGlucoseReadingsAsync(userId);
        return mapper.Map<IEnumerable<GlucoseReadingDTO>>(glucoseReading);
    }

    public async Task<GlucoseReadingDTO> GetById(int? id)
    {
        var glucoseReadingEntity = await glucoseReadingRepository.GetByIdAsync(id);
        return mapper.Map<GlucoseReadingDTO>(glucoseReadingEntity);
    }

    public Task Add(GlucoseReadingDTO glucoseReadingDto)
    {
        var glucoseReadingEntity = mapper.Map<GlucoseReadingEntity>(glucoseReadingDto);

        var insulin = insulinRepository.GetByIdAsync(glucoseReadingEntity.IdTypeInsulin).Result;

        if (insulin.IndividualApplication != false) return glucoseReadingRepository.CreateAsync(glucoseReadingEntity);
        
        if (glucoseReadingEntity.IdTypeInsulinSecond == null)
        {
            throw new ArgumentNullException(nameof(glucoseReadingDto), 
                "A segunda insulina deve ser informada quando a insulina não tiver aplicação individual true.");
        }
            
        if (glucoseReadingEntity.InsulinDoseSecond == null)
        {
            throw new ArgumentNullException(nameof(glucoseReadingDto), 
                "A segunda dose de insulina deve ser informada quando a insulina não tiver aplicação individual true.");
        }

        return glucoseReadingRepository.CreateAsync(glucoseReadingEntity);
    }

    public async Task Update(GlucoseReadingDTO glucoseReadingDto)
    {
        var glucoseReading = mapper.Map<GlucoseReadingEntity>(glucoseReadingDto);
        await glucoseReadingRepository.UpdateAsync(glucoseReading);
    }

    public async Task Remove(int? id)
    {
        var glucoseReadingEntity = glucoseReadingRepository.GetByIdAsync(id).Result;
        await glucoseReadingRepository.RemoveAsync(glucoseReadingEntity);
    }

    public Task<decimal> GetSuggestedDose(SuggestedDoseDTO suggestedDoseDto)
    {
        if (suggestedDoseDto == null)
        {
            throw new ArgumentNullException(nameof(suggestedDoseDto), "O objeto não pode ser nulo.");
        }
        
        decimal dose = 0;
        var insulinDose = insulinDoseRepository.GetByIdAsync(suggestedDoseDto.IdInsulinDose).Result;

        if (insulinDose == null)
        {
            throw new ArgumentNullException(nameof(insulinDose), "Não foi localizada uma dose para o tipo de insulina fornecido");
        }
        
        while (suggestedDoseDto.CarbohydrateAmount >= 5)
        {
            dose += 0.25m;
            suggestedDoseDto.CarbohydrateAmount -= 5;
        }
        
        //Desenvolver lógica futuramente, pois hoje não se sabe um calculo adequado para o mesmo. 
        /*while (suggestedDoseDto.CalorieAmount >= 5)
        {
            dose += 0.25m;
            suggestedDoseDto.CalorieAmount -= 5;
        }
        
        while (suggestedDoseDto.ProteinAmount >= 5)
        {
            dose += 0.25m;
            suggestedDoseDto.ProteinAmount -= 5;
        }*/

        if (suggestedDoseDto.ValueGlucose <= 120) 
            return Task.FromResult(dose + Convert.ToDecimal(insulinDose.Amount));
        
        while (suggestedDoseDto.ValueGlucose >= 130)
        {
            dose += 0.25m;
            suggestedDoseDto.ValueGlucose -= 10;
        }

        return Task.FromResult(dose + Convert.ToDecimal(insulinDose.Amount));
    }
}