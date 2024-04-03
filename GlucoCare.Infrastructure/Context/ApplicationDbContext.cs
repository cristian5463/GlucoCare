using GlucoCare.Domain.Entities;
using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<InsulinEntity> Insulin { get; set; }
    public DbSet<UserEntity> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}
