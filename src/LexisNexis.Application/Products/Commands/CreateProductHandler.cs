using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Application.Products.Commands;

public class CreateProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<CreateProductHandler> _logger;

    public CreateProductHandler(IProductRepository productRepository, ILogger<CreateProductHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task Handle(CreateProductCommand command)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            CategoryId = command.CategoryId,
            UnitPrice =  command.UnitPrice,
            SKU =  command.SKU,
            CreatedAt =  DateTime.UtcNow,
            UpdatedAt =   DateTime.UtcNow
        };

        await _productRepository.Insert(product);

        _logger.LogInformation("Product created with ID: {ProductId}", product.Id);
    }
}
