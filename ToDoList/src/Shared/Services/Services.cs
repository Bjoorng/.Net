using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Services;  

public static class Services
{
    public static IServiceCollection AddMyLibraryServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
