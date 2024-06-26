﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Domain.Entities;
[Table("AspNetUsers")]
public class UserUpdateEntity : IdentityUser
{
    public int IdUser { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}
