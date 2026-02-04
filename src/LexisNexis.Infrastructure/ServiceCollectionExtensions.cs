using LexisNexis.Application.Repositories;
using LexisNexis.Application.Services;
using LexisNexis.Domain.Entities;
using LexisNexis.Infrastructure.Repositories;
using LexisNexis.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LexisNexis.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICacheService<Product>, CacheService<Product>>();

        return services;
    }
}
