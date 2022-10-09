using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extenstions;

public static class Registrator
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.RegisterServices();
        
        return services;
    }
    
    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        
        return services;
    }
}