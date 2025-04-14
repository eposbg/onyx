using eCommerce.Products.Application.Services.Product;
using eCommerce.Products.Application.Tests.Infrastructure;
using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace eCommerce.Products.Application.Tests.Services;

public class ProductServiceTests
{
    [Fact]
    public async Task GetByColorAsync_ShouldReturnOnlyRedProducts()
    {
        // Arrange
        var context = DbContextFactory.CreateInMemoryContext();
        context.Products.AddRange(
            new Product { Id = 1, Name = "Shirt", Color = "Red" },
            new Product { Id = 2, Name = "Shoes", Color = "Blue" },
            new Product { Id = 3, Name = "Hat", Color = "Red" }
        );
        context.SaveChanges();

        var repository = new ProductRepository(context);
        var service = new ProductService(repository);

        // Act
        var result = await service.GetByColorAsync("Red", CancellationToken.None);

        // Assert
        result.Should().HaveCount(2);
        result.All(p => p.Color == "Red").Should().BeTrue();
    }
}