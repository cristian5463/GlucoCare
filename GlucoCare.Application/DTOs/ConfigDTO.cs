using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GlucoCare.Application.DTOs;
public class ConfigDTO
{
    public int Id { get; set; }
    public bool ApplyInsulinSnack { get; set; }
    public bool UseCarbsCalc { get; set; }
    public int IdUser {  get; set; }
}
