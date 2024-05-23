using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Domains.Entities;
using WebApi.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFastEndpoints()
    .SwaggerDocument();
builder.Services.AddDbContext<ApplicationDbContext>(opt => {
    opt.UseInMemoryDatabase(nameof(TodoList));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.UseFastEndpoints().UseSwaggerGen();

app.Run();