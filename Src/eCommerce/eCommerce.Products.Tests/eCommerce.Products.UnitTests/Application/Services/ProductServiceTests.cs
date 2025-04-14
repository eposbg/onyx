using eCommerce.Products.Application.Services.Product;
using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Domain.Repositories;
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
    public void GetAll_ShouldReturnAllProducts()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Shirt", Color = "Red" },
            new() { Id = 2, Name = "Shoes", Color = "Blue" }
        };
        _repoMock.Setup(r => r.GetAll()).Returns(products);

        // Act
        var result = _service.GetAllAsync(CancellationToken.None);

        // Assert
        result.Should().HaveCount(2);
        result.First().Name.Should().Be("Shirt");
    }
    
    [Fact]
    public void GetProductsByColor_ShouldReturnFilteredProducts()
    {
        // Arrange
        var color = "Red";
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Shirt", Color = "Red" },
            new Product { Id = 2, Name = "Hat", Color = "Red" }
        };
        _repoMock.Setup(r => r.GetByColor(color)).Returns(products);

        // Act
        var result = _service.GetProductsByColor(color);

        // Assert
        result.Should().OnlyContain(p => p.Color == "Red");
        result.Should().HaveCount(2);
    }
}