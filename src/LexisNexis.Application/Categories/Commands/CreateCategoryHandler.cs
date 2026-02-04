using LexisNexis.Application.Products.Commands;
using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Application.Categories.Commands;

public class CreateCategoryHandler
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CreateCategoryHandler> _logger;

    public CreateCategoryHandler(ICategoryRepository categoryRepository, ILogger<CreateCategoryHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            ParentCategoryId = null
        };

        await _categoryRepository.Insert(category);

        _logger.LogInformation("Category  created with ID: {CategoryId}", category.Id);
    }
}