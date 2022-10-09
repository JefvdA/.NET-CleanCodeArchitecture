using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extenstions;

public static class Registrator
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.RegisterDbContext();

        return services;
    }
    
    public static IServiceCollection RegisterDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CleanCodeArchitectureDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

        return services;
    } 
}