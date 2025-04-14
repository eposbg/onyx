using eCommerce.Products.Domain.Entries;
using eCommerce.Products.Infrastructure.Persistence;
using eCommerce.Products.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Products.UnitTests.Infrastructure.Repositories;

public class ProductRepositoryTests
{
    [Fact]
    public void GetAll_ShouldReturnQueryableProducts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ProductsContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using var context = new ProductsContext(options);
        context.Products.AddRange(
            new Product { Id = 1, Name = "Shirt", Color = "Red" },
            new Product { Id = 2, Name = "Shoes", Color = "Blue" }
        );
        context.SaveChanges();

        var repository = new ProductRepository(context);

        // Act
        var query = repository.GetAll();
        var result = query.ToList();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(p => p.Name == "Shirt");
    }
}