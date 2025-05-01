using Ambev.DeveloperEvaluation.Application.Products.GetProductById;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class GetProductByIdQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly GetProductByIdQueryHandler _handler;

        public GetProductByIdQueryHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new GetProductByIdQueryHandler(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var product = new Product
            {
                Id = productId,
                Title = "Test Product",
                Price = 10.99m
            };
            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);

            var query = new GetProductByIdQuery(productId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(productId);
            result.Title.Should().Be("Test Product");
        }
    }

}
