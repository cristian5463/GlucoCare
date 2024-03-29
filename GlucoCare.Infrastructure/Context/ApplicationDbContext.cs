﻿using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlucoCare.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<InsulinEntity> Insulin { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);
    }
}
