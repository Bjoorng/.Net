using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints2.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
