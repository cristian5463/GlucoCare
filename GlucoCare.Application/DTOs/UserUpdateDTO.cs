using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GlucoCare.Application.DTOs
{
    public class UserUpdateDTO
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
