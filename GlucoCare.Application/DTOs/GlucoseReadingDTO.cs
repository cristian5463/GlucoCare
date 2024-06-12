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
        [MinLength(1)]
        [MaxLength(7)]
        public int ValueGlucose { get; set; }
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime ReadingDate { get; set; }
        [Required(ErrorMessage = "A hora é obrigatória")]
        public DateTime ReadingTime { get; set; }
        public string MealType { get; set; }
        public int ProteinAmount { get; set; }
        public int CarbohydrateAmount { get; set; }
        public int CalorieAmount { get; set; }
        [Required(ErrorMessage = "A insulina é obrigatória")]
        public int IdTypeInsulin { get; set; }
        [Required(ErrorMessage = "A dose da insulina é obrigatória")]
        [MinLength(1)]
        [MaxLength(7)]
        public int InsulinDose { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}