using Aplication.Implements.Actores;
using Aplication.Implements.Directores;
using Aplication.Implements.Generos;
using Aplication.Implements.Paises;
using Aplication.Implements.Peliculas;
using Aplication.Implements.Usuarios;
using Aplication.Interface.Actores;
using Aplication.Interface.Directores;
using Aplication.Interface.Generos;
using Aplication.Interface.Paises;
using Aplication.Interface.Peliculas;
using Aplication.Interface.Usuarios;
using Infrastructure.Implements.Actores;
using Infrastructure.Implements.Directores;
using Infrastructure.Implements.Generos;
using Infrastructure.Implements.Paises;
using Infrastructure.Implements.Peliculas;
using Infrastructure.Implements.Usuarios;
using Infrastructure.Interface.Actores;
using Infrastructure.Interface.Directores;
using Infrastructure.Interface.Generos;
using Infrastructure.Interface.Paises;
using Infrastructure.Interface.Peliculas;
using Infrastructure.Interface.Usuarios;
using Microsoft.EntityFrameworkCore;
using WebSeries.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://webseriesapp-dacng0gyf6ejf8cx.eastus-01.azurewebsites.net", "http://localhost:4200") 
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

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de inyección de dependencias de la capa de Aplicacion 
builder.Services.AddScoped<IActoresService, ActoresService>();
builder.Services.AddScoped<IDirectoresService, DirectoresService>();
builder.Services.AddScoped<IGenerosService, GenerosService>();
builder.Services.AddScoped<IPeliculasService, PeliculasService>();
builder.Services.AddScoped<IPaisesService, PaisesService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

// Configuración de inyección de dependencias de la capa de Infrastructura
builder.Services.AddScoped<IActoresRepository, ActoresRepository>();
builder.Services.AddScoped<IDirectoresRepository, DirectoresRepository>();
builder.Services.AddScoped<IGenerosRepository, GenerosRepository>();
builder.Services.AddScoped<IPeliculasRepository, PeliculasRepository>();
builder.Services.AddScoped<IPaisesRepository, PaisesRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();


var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error != null)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error",
                Details = error.Error.Message
            });
        }
    });
});

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World");

app.Run();


