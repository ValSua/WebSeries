using Aplication.Implements;
using Aplication.Interface;
using Infrastructure.Implements;
using Infrastructure.Interface;
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

// Configuración de inyección de dependencias de la capa de Infrastructura
builder.Services.AddScoped<IActoresRepository, ActoresRepository>();



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
