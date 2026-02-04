using LexisNexis.Application.Repositories;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Application.Products.Commands;

public class DeleteProductHandler
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<DeleteProductHandler> _logger;

    public DeleteProductHandler(IProductRepository productRepository, ILogger<DeleteProductHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task Handle(DeleteProductCommand command)
    {
        await _productRepository.Delete(command.Id);

        _logger.LogInformation("Product with ID: {ProductId} successfully deleted", command.Id);
    }
}
