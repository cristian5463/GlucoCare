using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using GlucoCare.CrossCutting.IoC;
using GlucoCare.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using GlucoCare.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructureAPI(builder.Configuration);

builder.Services
    .AddIdentity<UserEntity, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalogo.API", Version = "v1" });
});

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure CORS
app.UseCors(builder => builder
    .AllowAnyOrigin() // Permitir qualquer origem
    .AllowAnyMethod() // Permitir qualquer método (GET, POST, etc.)
    .AllowAnyHeader()); // Permitir qualquer cabeçalho

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
