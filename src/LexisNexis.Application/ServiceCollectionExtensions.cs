using LexisNexis.Application.Categories.Commands;
using LexisNexis.Application.Categories.Queries;
using LexisNexis.Application.Products.Commands;
using LexisNexis.Application.Products.Queries;
using LexisNexis.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LexisNexis.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateProductHandler>();
        services.AddScoped<GetProductByIdHandler>();
        services.AddScoped<UpdateProductHandler>();
        services.AddScoped<DeleteProductHandler>();
        services.AddScoped<SearchProductHandler>();
        services.AddScoped<CreateCategoryHandler>();
        services.AddScoped<GetCategoryHierarchyTreeHandler>();

        return services;
    }
}
