using LexisNexis.Application.Products.Commands;
using LexisNexis.Application.Products.Queries;
using LexisNexis.Application.Repositories;
using LexisNexis.Application.Services;
using LexisNexis.Domain.Entities;
using Moq;
using Microsoft.Extensions.Logging;

namespace LexisNexis.Tests.Application;

[TestFixture]
public class ApplicationTests
{
    private Mock<IProductRepository> _productRepository;
    private Mock<ILogger<CreateProductHandler>> _mockHandlerLogger;
    private Mock<ICacheService<Product>> _mockMemoryCache;
    private CreateProductHandler _createProductHandler;
    private SearchProductHandler _searchProductHandler;
    private Guid _categoryId;
    
    [SetUp]
    public void SetUp()
    {
        _categoryId = Guid.NewGuid();
        
        _productRepository = new Mock<IProductRepository>();
        _productRepository
            .Setup(r => r.Insert(It.IsAny<Product>()));
        _productRepository
            .Setup(r => r.GetAll())
            .Returns(It.IsAny<IEnumerable<Product>>());
        
        _mockMemoryCache = new Mock<ICacheService<Product>>();
        _mockMemoryCache
            .Setup(r => r.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Product>>()));
        _mockMemoryCache
            .Setup(r => r.Get(It.IsAny<string>()))
            .Returns(new List<Product>()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "test",
                    Description = "test",
                    CategoryId = _categoryId,
                    UnitPrice =  1,
                    SKU =  "qwe",
                    CreatedAt =  DateTime.UtcNow,
                    UpdatedAt =   DateTime.UtcNow
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "zz",
                    Description = "zz",
                    CategoryId = Guid.NewGuid(),
                    UnitPrice =  1,
                    SKU =  "qwe2",
                    CreatedAt =  DateTime.UtcNow,
                    UpdatedAt =   DateTime.UtcNow
                }
            });
        
        _mockHandlerLogger = new Mock<ILogger<CreateProductHandler>>();
        _createProductHandler = new CreateProductHandler(_productRepository.Object, _mockHandlerLogger.Object);
        
        _searchProductHandler = new SearchProductHandler(_productRepository.Object, _mockMemoryCache.Object);
    }

    [Test]
    public async Task CreateProductHandler_Should_persist_product_to_repository()
    {
        // Arrange
        var createCommand = new CreateProductCommand()
        {
            Name = "test",
            Description = "test",
            CategoryId = Guid.NewGuid(),
            UnitPrice =  1,
            SKU =  "sku",
        };
        
        // Act
        await _createProductHandler.Handle(createCommand);
            
        // Assert
        _productRepository.Verify(r => r.Insert(It.IsAny<Product>()), Times.Once);
    }

    [Test]
    public async Task SearchProductHandler_Should_return_products_from_cache_if_available()
    {
        // Arrange
        var createCommand = new CreateProductCommand()
        {
            Name = "test",
            Description = "test",
            CategoryId = _categoryId,
            UnitPrice =  1,
            SKU =  "sku",
        };
        
        var searchCommand = new SearchProductQuery()
        {
            SearchTerm = "test",
            CategoryId = _categoryId,
            PageNumber =  1,
            PageSize = 2,
        };
        
        // Act
        await _createProductHandler.Handle(createCommand);
        var result =  _searchProductHandler.Handle(searchCommand);
            
        // Assert
        Assert.That(result.Any());
    }
}
