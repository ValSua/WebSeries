using Aplication.Implements.Actores;
using Aplication.Implements.Directores;
using Aplication.Interface.Actores;
using Aplication.Interface.Directores;
using Infrastructure.Implements.Actores;
using Infrastructure.Implements.Directores;
using Infrastructure.Interface.Actores;
using Infrastructure.Interface.Directores;
using WebSeries.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectDbContext>();

// Configuración de inyección de dependencias de la capa de Aplicacion 
builder.Services.AddScoped<IActoresService, ActoresService>();
builder.Services.AddScoped<IDirectoresService, DirectoresService>();

// Configuración de inyección de dependencias de la capa de Infrastructura
builder.Services.AddScoped<IActoresRepository, ActoresRepository>();
builder.Services.AddScoped<IDirectoresRepository, DirectoresRepository>();


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
