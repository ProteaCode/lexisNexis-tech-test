using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;
using LexisNexis.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ILogger<Category> logger)
        : base(logger)
    {
        
    }
}