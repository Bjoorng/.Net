using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Services;
using System.Reflection;
using WebApi.Consts;
using WebApi.Infastructure.Data.Interceptors;
using WebApi.Infrastructure.Data;
using WebApi.Infrastructure.Data.Interceptors;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors(options =>
{
    var origins = builder.Configuration.GetValue<string>("Cors:WithOrigins")?.Split(";") ?? Array.Empty<string>();
    options.AddPolicy(name: Constants.MY_ALLOW_SPECIFIC_ORIGINS,
                      policy =>
                      {
                          policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
builder.Services.AddScoped<ISaveChangesInterceptor, ProgressiveEntityInterceptor>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFastEndpoints().SwaggerDocument();
builder.Services.AddDbContext<ApplicationDbContext>((sp, o) =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    o.AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>());
});
builder.Services.AddTransient<IUser, User>();
builder.Services.AddSharedServices();
//builder.Services.AddDbContext<ApplicationDbContext>(o =>
//{
//    o.UseInMemoryDatabase(nameof(TodoList));
//});



builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseCors(Constants.MY_ALLOW_SPECIFIC_ORIGINS);
app.UseFastEndpoints().UseSwaggerGen();

app.MapGet("/", () => "Hello World");

app.Run();