using GlucoCare.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Infrastructure.Context;
public class UserDbContext : IdentityDbContext<UserEntity>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {

    }
}
