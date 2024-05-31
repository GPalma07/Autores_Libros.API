using Autores_Libros.Application.AutoresAPP;
using Autores_Libros.Application.Configuraciones;
using Autores_Libros.Application.LibrosAPP;
using Autores_Libros.DaraAccess.Models;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Grupo Vision",
        Description = "API de prueba técnica de Gerardo Palma"
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddTransient<IAutoresAPP, AutoresAPP>();
builder.Services.AddTransient<ILibrosAPP, LibrosAPP>();
builder.Services.AddTransient<IConfig, Config>();
builder.Services.AddTransient<AutoresLibrosContext>();

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
