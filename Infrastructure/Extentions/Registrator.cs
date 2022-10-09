using System.Reflection;
using Application.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.UoW;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions;

public static class Registrator
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.RegisterDbContext();
        services.RegisterRepositories();

        return services;
    }

    private static IServiceCollection RegisterDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CleanCodeArchitectureDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

        return services;
    }
    
    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}