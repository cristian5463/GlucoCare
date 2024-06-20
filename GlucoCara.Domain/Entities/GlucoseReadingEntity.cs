using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlucoCare.Domain.Entities;
public class GlucoseReadingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    private int _valueGlucose;
    private DateTime _readingDateTime;
    private int _idTypeInsulin;
    private int _insulinDose;
    private DateTime _updatedAt;

    public GlucoseReadingEntity(int valueGlucose, DateTime readingDateTime,  int idTypeInsulin, int insulinDose)
    {
        ValueGlucose = valueGlucose;
        ReadingDateTime = readingDateTime;
        IdTypeInsulin = idTypeInsulin;
        InsulinDose = insulinDose;
        CreatedAt = DateTime.UtcNow;
    }

    public int ValueGlucose
    {
        get => _valueGlucose;
        private set
        {
            if (value < 1 || value > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "O Valor da Glicose deve estar entre 1 e 1000.");
            }
            _valueGlucose = value;
        }
    }
    public DateTime ReadingDateTime
    {
        get => _readingDateTime;
        private set
        {
            if (value == default)
            {
                throw new ArgumentException("A data é obrigatória.", nameof(value));
            }
            _readingDateTime = value;
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
    
    public int? IdTypeInsulinSecond { get; private set; }

    public int InsulinDose
    {
        get => _insulinDose;
        private set
        {
            if (value < 1 && value > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "A dose da insulina deve estar entre 1 e 1000.");
            }
            _insulinDose = value;
        }
    }
    
    public int? InsulinDoseSecond { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt
    {
        get => _updatedAt; 
        private set =>  _updatedAt = DateTime.UtcNow; 
    }
    
    public int IdUser { get; private set; }
    
    [Column(TypeName = "time")]
    public TimeSpan TimeOnly { get; private set; }
}
