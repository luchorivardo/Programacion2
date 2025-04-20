using Datos.Context;
using Datos.Repositorios;
using Datos.Repositorios.Interfaces;
using Logica.Implementaciones;
using Logica.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddScoped<IAnimalesLogic, AnimalesLogic>();
builder.Services.AddScoped<IAnimalRepositorio, AnimalRepositorio>();
builder.Services.AddScoped<IAtencionRepositorio, AtencionRepositorio>();
builder.Services.AddScoped<IAtencionesLogic, AtencionesLogic>();
builder.Services.AddScoped<IDuenoRepositorio, DuenoRepositorio>();
builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();
builder.Services.AddScoped<IDuenoLogic, DuenoLogic>();
builder.Services.AddScoped<ITipoLogic, TipoLogic>();

var app = builder.Build();

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
