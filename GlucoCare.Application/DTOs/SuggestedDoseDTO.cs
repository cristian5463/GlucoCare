using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GlucoCare.source.Dtos
{
    public class SuggestedDoseDTO
    {
        [JsonIgnore]
        public int IdUser { get; set; }
        
        [Required(ErrorMessage = "O Valor da Glicose é obrigatório")]
        [Range(1, 1000, ErrorMessage = "O Valor da Glicose deve estar entre 1 e 1000.")]
        public int ValueGlucose { get; set; }
        
        public string MealType { get; set; }
        public int ProteinAmount { get; set; }
        public int CarbohydrateAmount { get; set; }
        public int CalorieAmount { get; set; }
        
        [Required(ErrorMessage = "O Id da insulina é obrigatório")]
        public int IdTypeInsulin { get; set; }
    }
}