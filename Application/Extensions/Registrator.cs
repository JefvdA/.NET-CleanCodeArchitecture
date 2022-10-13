using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class Registrator
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.RegisterMediatr();
        services.RegisterMapper();
        
        return services;
    }

    private static IServiceCollection RegisterMediatr(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Registrator).Assembly);
        
        return services;
    }

    private static IServiceCollection RegisterMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Registrator).Assembly);

        return services;
    }
}