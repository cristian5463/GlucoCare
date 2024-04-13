using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.DTOs;
public class UserDTO
{
    public int IdUser { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    /*[Required]
    [Compare("Password")]
    public string RePassword { get; set; }*/
    [Required]
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
