using LexisNexis.Application.DTOs;
using LexisNexis.Application.Extensions;
using LexisNexis.Application.Repositories;
using LexisNexis.Application.Services;
using LexisNexis.Domain.Entities;

namespace LexisNexis.Application.Products.Queries;

public class SearchProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ICacheService<Product> _memoryCache;
    
    public SearchProductHandler(IProductRepository productRepository, ICacheService<Product> memoryCache)
    {
        _productRepository = productRepository;
        _memoryCache = memoryCache;
    }

    public IEnumerable<ProductDto> Handle(SearchProductQuery query)
    {
        var cachedProducts = _memoryCache.Get(query.SearchTerm);

        if (cachedProducts.Any())
        {
            return cachedProducts.Select(x =>
                new ProductDto(
                    x.Id,
                    x.Name,
                    x.Description,
                    x.CategoryId,
                    x.UnitPrice,
                    x.SKU,
                    x.UpdatedAt,
                    x.CreatedAt));
        }
        
        var products = _productRepository.GetAll();
        
        // Search
        var filteredProducts = products?.Search<Product>(query.SearchTerm, x => x.Name);
           
        // Filter by cat + paginate
        filteredProducts = filteredProducts?
            .Where(x => x.CategoryId == query.CategoryId)
            .Skip(query.PageNumber)
            .Take(query.PageSize);

        if (!filteredProducts.Any())
            return Enumerable.Empty<ProductDto>();
        
        _memoryCache.Set(query.SearchTerm, filteredProducts);
        
        return filteredProducts.Select(x =>
            new ProductDto(
                x.Id,
                x.Name,
                x.Description,
                x.CategoryId,
                x.UnitPrice,
                x.SKU,
                x.UpdatedAt,
                x.CreatedAt));
    }
}