using GlucoCare.Application.Interfaces;
using GlucoCare.Application.Mappings;
using GlucoCare.Application.Services;
using GlucoCare.Domain.Interfaces;
using GlucoCare.Infrastructure.Context;
using GlucoCare.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.CrossCutting.IoC;
public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>
            (options => options.UseNpgsql(connectionString));

        services.AddScoped<IInsulinRepository, InsulinRepository>();
        services.AddScoped<IInsulinService, InsulinService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
