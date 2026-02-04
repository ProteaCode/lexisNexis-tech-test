using LexisNexis.Application.DTOs;
using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Application.Products.Commands;

public class UpdateProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<UpdateProductHandler> _logger;


    public UpdateProductHandler(IProductRepository productRepository, 
        ILogger<UpdateProductHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public ProductDto Handle(UpdateProductCommand command)
    {
        var product = new Product
        {
            Id = command.Id,
            Name = command.Name,
            Description = command.Description,
            CategoryId = command.CategoryId,
            UnitPrice =  command.UnitPrice,
            SKU =  command.SKU,
            CreatedAt =  DateTime.UtcNow,
            UpdatedAt =   DateTime.UtcNow
        };

         var result = _productRepository.Update(product);

        _logger.LogInformation("Product with ID: {ProductId}, updated successfully", product.Id);

        // Could probably use mapper for this
        //
        return new ProductDto(result.Id, 
            result.Name, 
            result.Description, 
            result.CategoryId, 
            result.UnitPrice, 
            result.SKU, 
            result.CreatedAt, 
            result.UpdatedAt);
    }
}
