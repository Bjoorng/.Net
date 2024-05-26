using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Shared.Services;
using System.Reflection;
using WebApi.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors(o => o.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddMyLibraryServices();
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

app.UseCors();
app.UseFastEndpoints().UseSwaggerGen();

app.Run();