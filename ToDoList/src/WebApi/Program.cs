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
//builder.Services.AddDbContext<ApplicationDbContext>(o =>
//{
//    o.UseInMemoryDatabase(nameof(TodoList));
//});

builder.Services.AddDbContext<ApplicationDbContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.UseFastEndpoints().UseSwaggerGen();

app.Run();