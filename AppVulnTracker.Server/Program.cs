
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using System.IO;
using AppVulnTracker.Server.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar servicios
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Registrar servicios propios
builder.Services.AddScoped<AplicationDbContext>();

// Configurar CORS (antes de Build)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HUB_API", Version = "v4" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// 2. Configurar middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// CORS - importante que esté antes de UseAuthentication/UseAuthorization
app.UseCors("PermitirTodo");

app.UseAuthentication();
app.UseAuthorization();

// Mapear rutas API
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Servir archivos estáticos desde wwwroot (si tienes)
app.UseStaticFiles();

// Servir archivos estáticos desde carpeta "imagenes"
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "imagenes")),
//    RequestPath = "/imagenes"
//});

// Aquí va app.Run() al final
app.Run();

