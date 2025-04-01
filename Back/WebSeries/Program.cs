using Aplication.Implements.Actores;
using Aplication.Implements.Directores;
using Aplication.Implements.Generos;
using Aplication.Implements.Paises;
using Aplication.Implements.Peliculas;
using Aplication.Interface.Actores;
using Aplication.Interface.Directores;
using Aplication.Interface.Generos;
using Aplication.Interface.Paises;
using Aplication.Interface.Peliculas;
using Infrastructure.Implements.Actores;
using Infrastructure.Implements.Directores;
using Infrastructure.Implements.Generos;
using Infrastructure.Implements.Paises;
using Infrastructure.Implements.Peliculas;
using Infrastructure.Interface.Actores;
using Infrastructure.Interface.Directores;
using Infrastructure.Interface.Generos;
using Infrastructure.Interface.Paises;
using Infrastructure.Interface.Peliculas;
using WebSeries.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Este es el puerto de tu frontend
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectDbContext>();

// Configuración de inyección de dependencias de la capa de Aplicacion 
builder.Services.AddScoped<IActoresService, ActoresService>();
builder.Services.AddScoped<IDirectoresService, DirectoresService>();
builder.Services.AddScoped<IGenerosService, GenerosService>();
builder.Services.AddScoped<IPeliculasService, PeliculasService>();
builder.Services.AddScoped<IPaisesService, PaisesService>();

// Configuración de inyección de dependencias de la capa de Infrastructura
builder.Services.AddScoped<IActoresRepository, ActoresRepository>();
builder.Services.AddScoped<IDirectoresRepository, DirectoresRepository>();
builder.Services.AddScoped<IGenerosRepository, GenerosRepository>();
builder.Services.AddScoped<IPeliculasRepository, PeliculasRepository>();
builder.Services.AddScoped<IPaisesRepository, PaisesRepository>();


var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
