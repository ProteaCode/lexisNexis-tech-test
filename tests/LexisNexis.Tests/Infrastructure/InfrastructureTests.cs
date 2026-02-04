using LexisNexis.Domain.Entities;
using LexisNexis.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace LexisNexis.Tests.Infrastructure
{
    [TestFixture]
    public class InfrastructureTests
    {
        private Mock<ProductRepository> _productRepository;
        private Mock<ILogger<Product>> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<Product>>();
            _productRepository = new Mock<ProductRepository>(_mockLogger.Object);
        }

        // Products
        //
        [Test]
        public async Task Insert_Should_Save_Product()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Description = "test",
                CategoryId = Guid.NewGuid(),
                UnitPrice =  1,
                SKU =  "qwe",
                CreatedAt =  DateTime.UtcNow,
                UpdatedAt =   DateTime.UtcNow
            };

            // Act
            await _productRepository.Object.Insert(product);

            // Assert
            var result = _productRepository.Object.GetAll();

            Assert.That(result.Any());
            Assert.That("test", Is.EqualTo(result.FirstOrDefault().Name));
        }
    }
}
