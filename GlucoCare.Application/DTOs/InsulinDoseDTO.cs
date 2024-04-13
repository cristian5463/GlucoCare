using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GlucoCare.Application.DTOs;
public class InsulinDoseDTO
{
    public int Id { get; set; }
    public int IdTypeInsulin { get; set; }
    public decimal Amount { get; set; }
    public int Correction { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
