using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GlucoCare.source.Dtos
{
    public class InsulinDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string NameInsulin { get; set; }
        public bool IndividualApplication { get; set; }
        [JsonIgnore]
        public int IdUser { get; set; }
        public int TypesInsulin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}