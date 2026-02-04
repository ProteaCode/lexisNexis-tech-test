using LexisNexis.Application.DTOs;
using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;

namespace LexisNexis.Application.Products.Queries;

public class GetProductByIdHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ProductDto Handle(GetProductByIdQuery query)
    {
        var product = _productRepository.GetById(query.Id);
        
        // Could probably use mapper for this
        //
        return new ProductDto(product.Id, 
            product.Name, 
            product.Description, 
            product.CategoryId, 
            product.UnitPrice, 
            product.SKU, 
            product.CreatedAt, 
            product.UpdatedAt);
    }
}
