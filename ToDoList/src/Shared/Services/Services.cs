using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Services;  

public static class SharedServices
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
