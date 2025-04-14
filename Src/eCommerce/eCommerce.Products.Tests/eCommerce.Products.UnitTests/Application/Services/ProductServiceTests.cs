using eCommerce.Products.Application.Services.Product;
using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Domain.Repositories;
using eCommerce.Products.UnitTests.Helpers;
using FluentAssertions;
using Moq;

namespace eCommerce.Products.UnitTests.Application.Services;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repoMock;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _repoMock = new Mock<IProductRepository>();
        _service = new ProductService(_repoMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProductsAsDtos()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Shirt", Color = "Red" },
            new() { Id = 2, Name = "Shoes", Color = "Blue" }
        };
        var asyncProducts = new TestAsyncEnumerable<Product>(products);
        _repoMock.Setup(r => r.GetAll()).Returns(asyncProducts);

        // Act
        var result = await _service.GetAllAsync(CancellationToken.None);

        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(products, options =>
            options.ExcludingMissingMembers());
    }

    [Fact]
    public async Task GetByColorAsync_ShouldReturnOnlyMatchingColor()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Shirt", Color = "Red" },
            new() { Id = 2, Name = "Shoes", Color = "Blue" },
            new() { Id = 3, Name = "Hat", Color = "Red" }
        };
        var asyncProducts = new TestAsyncEnumerable<Product>(products);
        _repoMock.Setup(r => r.GetAll()).Returns(asyncProducts);

        // Act
        var result = await _service.GetByColorAsync("Red", CancellationToken.None);

        // Assert
        result.Should().HaveCount(2);
        result.Select(p => p.Color).Should().AllBe("Red");
    }
}