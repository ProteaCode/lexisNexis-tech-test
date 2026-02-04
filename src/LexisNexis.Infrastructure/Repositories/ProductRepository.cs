using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;
using LexisNexis.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository    
{
    public ProductRepository(ILogger<Product> logger) 
        : base(logger)
    {
    }
}
