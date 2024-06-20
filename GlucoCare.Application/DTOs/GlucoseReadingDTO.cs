using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GlucoCare.source.Dtos
{
    public class GlucoseReadingDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        [Required(ErrorMessage = "O Valor da Glicose é obrigatório")]
        [Range(1, 1000, ErrorMessage = "O Valor da Glicose deve estar entre 1 e 1000.")]
        public int ValueGlucose { get; set; }

        [Required(ErrorMessage = "A data da leitura é obrigatória")]
        public DateTime ReadingDateTime { get; set; }
        
        public string MealType { get; set; }
        public int ProteinAmount { get; set; }
        public int CarbohydrateAmount { get; set; }
        public int CalorieAmount { get; set; }

        [Required(ErrorMessage = "A insulina é obrigatória")]
        public int IdTypeInsulin { get; set; }

        [Required(ErrorMessage = "A dose da insulina é obrigatória")]
        [Range(1, 1000, ErrorMessage = "A dose da insulina deve estar entre 1 e 1000.")]
        public int InsulinDose { get; set; }

        public int IdTypeInsulinSecond { get; set; }
        public int InsulinDoseSecond { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TimeSpan TimeOnly { get; set; }
    }
}