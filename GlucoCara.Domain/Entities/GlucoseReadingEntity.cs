using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlucoCare.Domain.Entities;
public class GlucoseReadingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    private int _valueGlucose;
    private DateTime _readingDate;
    private DateTime _readingTime;
    private int _idTypeInsulin;
    private int _insulinDose;

    public GlucoseReadingEntity(int valueGlucose, DateTime readingDate, DateTime readingTime, int idTypeInsulin, int insulinDose)
    {
        ValueGlucose = valueGlucose;
        ReadingDate = readingDate;
        ReadingTime = readingTime;
        IdTypeInsulin = idTypeInsulin;
        InsulinDose = insulinDose;
        CreatedAt = DateTime.UtcNow;
    }

    public int ValueGlucose
    {
        get => _valueGlucose;
        private set
        {
            if (value is < 1 or > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "O Valor da Glicose deve estar entre 1 e 1000.");
            }
            _valueGlucose = value;
        }
    }

    public DateTime ReadingDate
    {
        get => _readingDate;
        private set
        {
            if (value == default)
            {
                throw new ArgumentException("A data é obrigatória.", nameof(value));
            }
            _readingDate = value;
        }
    }

    public DateTime ReadingTime
    {
        get => _readingTime;
        private set
        {
            if (value == default)
            {
                throw new ArgumentException("A hora é obrigatória.", nameof(value));
            }
            _readingTime = value;
        }
    }

    public string MealType { get; private set; }

    public int ProteinAmount { get; private set; }

    public int CarbohydrateAmount { get; private set; }

    public int CalorieAmount { get; private set; }

    public int IdTypeInsulin
    {
        get => _idTypeInsulin;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException("A insulina é obrigatória.", nameof(value));
            }
            _idTypeInsulin = value;
        }
    }

    public int InsulinDose
    {
        get => _insulinDose;
        private set
        {
            if (value is < 1 or > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "A dose da insulina deve estar entre 1 e 1000.");
            }
            _insulinDose = value;
        }
    }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public void UpdateTimestamps()
    {
        UpdatedAt = DateTime.UtcNow;
    }
    
    public int IdUser { get; private set; }
}
