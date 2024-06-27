using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Domain.Entities;
[Table("AspNetUsers")]
public class UserEntity : IdentityUser
{
    private DateTime updatedAt;
    
    [Key] // Marcar como chave primária
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdUser { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt
    {
        get { return updatedAt; }
        private set { updatedAt = DateTime.UtcNow; }
    }
    public UserEntity() : base() { }
    
}
