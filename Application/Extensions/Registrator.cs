using Application.Interfaces;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class Registrator
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.RegisterServices();
        services.RegisterMediatr();
        
        return services;
    }
    
    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        
        return services;
    }
    
    private static IServiceCollection RegisterMediatr(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Registrator).Assembly);
        
        return services;
    }
}